using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LidarGun : MonoBehaviour
{
    [SerializeField] private bool canDamageDoll;
    [SerializeField] private int dollDamage;
    [SerializeField] private Color lidarColor = Color.white;
    [SerializeField] private Color altLidarColor = Color.yellow;
    [SerializeField] private Color dollColor = Color.red;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource additionalAudioSource;
    [SerializeField] private AudioClip changeRadiusAudioClip;
    [SerializeField] private AudioClip changeModeAudioClip;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private BatteryPercentage battery;
    [SerializeField] private Transform rayStartPoint;
    [SerializeField] private Transform circleCrosshair;
    [SerializeField] private float maxDistance, minRadius, maxRadius;
    [SerializeField] private GameObject[] crosshairs;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private Transform particleSystemTransform;

    private InputMaster _inputMaster;
    private InputAction _changeRadiusAction;
    private float _radius = 10;
    private int _currentMode;

    private Coroutine _gunCoroutine;

    NativeArray<Color32> _texturePixels = new NativeArray<Color32>();

    private void Awake()
    {
        _inputMaster = new InputMaster();
        _inputMaster.Inputs.Usegun.started += _ => UseGun();
        _inputMaster.Inputs.Usegun.canceled += _ => StopUsingGun();
        _inputMaster.Inputs.Changemode.performed += _ => ChangeMode();

        _changeRadiusAction = _inputMaster.Inputs.Changeradius;
        _changeRadiusAction.performed += _ => ChangeRadius();
    }

    private void UseGun()
    {
        if (battery.BatteryEnergy == 0) return;

        if (_gunCoroutine == null)
        {
            playerMovement.Speed /= 2;
            battery.MultiplyInterval(0.25f);
            audioSource.Play();
            if (_currentMode == 0) _gunCoroutine = StartCoroutine(UseWideLidar());
            else if (_currentMode == 1) _gunCoroutine = StartCoroutine(UseCircleLidar());
        }
    }

    private void StopUsingGun()
    {
        if (battery.BatteryEnergy == 0) return;

        if (_gunCoroutine != null && _currentMode == 1)
        {
            playerMovement.Speed *= 2;
            audioSource.Stop();
            StopCoroutine(_gunCoroutine);
            battery.MultiplyInterval(4);
            _gunCoroutine = null;
        }
    }

    private void ChangeMode()
    {
        if (_gunCoroutine != null) return;

        crosshairs[_currentMode].SetActive(false);
        _currentMode += 1;
        if (_currentMode > 1) _currentMode = 0;
        crosshairs[_currentMode].SetActive(true);
        additionalAudioSource.PlayOneShot(changeModeAudioClip);
    }

    private float RoundToNearestFive(float value)
    {
        return Mathf.Round(value * 100 / 5f) / 100 * 5f; //4.04 > 404 > 400 > 4.00
    }

    private void SpawnParticle()
    {
        if (Physics.Raycast(rayStartPoint.position, rayStartPoint.forward, out RaycastHit hit, maxDistance))
        {
            Vector3 hitPoint = hit.point;
            hitPoint = new Vector3(RoundToNearestFive(hitPoint.x), RoundToNearestFive(hitPoint.y), RoundToNearestFive(hitPoint.z));
            if (hit.collider.gameObject.layer == LayerMask.GetMask("Lidar dots")) return;

            Debug.DrawRay(hitPoint, hit.normal, Color.red, 5f);
            Texture2D currentTexture = (Texture2D)hit.collider.GetComponent<Renderer>().material.mainTexture;
            if (!currentTexture.isReadable) return;

            _texturePixels = currentTexture.GetRawTextureData<Color32>();
            Vector2 UVcords = hit.textureCoord;
            UVcords.x *= currentTexture.width;
            UVcords.y *= currentTexture.height;

            //int pixelIndex = (int)UVcords.y * currentTexture.width + (int)UVcords.x;
            if (hit.collider.TryGetComponent(out Doll doll))
            {
                particleSystem.startColor = dollColor;
                if (canDamageDoll) doll.GetDamage(dollDamage);
            }
            else
            {
                Color pixelColor =  currentTexture.GetPixelBilinear(UVcords.x, UVcords.y);
                particleSystem.startColor = pixelColor;
            }

            particleSystemTransform.position = hitPoint;
            particleSystem.Emit(1);
        }
    }

    private IEnumerator UseWideLidar()
    {
        for (float i = -24; i < 25; i += _radius / 10)
        {
            for (float j = -30; j < 31; j += _radius / 10)
            {
                if (battery.BatteryEnergy == 0) yield return 0;
                rayStartPoint.localEulerAngles = new Vector3(i, j, 0);
                //try
                //{
                    SpawnParticle();
                //}
               // catch
                //{
                //    continue;
                //}
            }

            yield return new WaitForSeconds(0.025f);
        }

        playerMovement.Speed *= 2;
        audioSource.Stop();
        StopCoroutine(_gunCoroutine);
        battery.MultiplyInterval(4);
        _gunCoroutine = null;
    }

    private IEnumerator UseCircleLidar()
    {
        while (true)
        {
            for (float i = 0; i < _radius * 2 + 1; i += _radius / 2 + (int)(Random.Range(-1f, 1f)*_radius))
            {
                rayStartPoint.localEulerAngles = Vector3.right * i;

                for (float j = 0; j < 360; j += _radius)
                {
                    if (battery.BatteryEnergy == 0) yield return 0;
                    rayStartPoint.RotateAround(rayStartPoint.parent.forward, _radius + (int)(Random.Range(-0.5f, 0.5f) * _radius));

                    try
                    {
                        SpawnParticle();
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            yield return new WaitForSeconds(0.075f);
        }
    }

    private void ChangeRadius()
    {
        if (_radius != minRadius && _radius != maxRadius) additionalAudioSource.PlayOneShot(changeRadiusAudioClip, 0.5f);
        _radius += _changeRadiusAction.ReadValue<float>() / 120;
        _radius = Mathf.Clamp(_radius, minRadius, maxRadius);
        circleCrosshair.localScale = Vector3.one * 0.07f * _radius;
    }

    private void OnEnable()
    {
        _inputMaster.Enable();
    }

    private void OnDisable()
    {
        _inputMaster.Inputs.Usegun.started -= _ => UseGun();
        _inputMaster.Inputs.Usegun.canceled -= _ => StopUsingGun();
        _inputMaster.Inputs.Changemode.performed -= _ => ChangeMode();
        _changeRadiusAction.performed -= _ => ChangeRadius();

        _inputMaster.Disable();
    }
}
