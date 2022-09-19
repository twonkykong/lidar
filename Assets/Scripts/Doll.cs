using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Audio;

public class Doll : MonoBehaviour
{
    [SerializeField] private DollSpawner dollSpawner;
    [SerializeField] private NavMeshAgent navmeshAgent;
    [SerializeField] private PlayerDeath playerDeath;
    [SerializeField] private CameraShaking cameraShaking;
    [SerializeField] private AudioSource hummmAudioSource;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private TextureCleaner textureCleaner;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Image vignette;
    [SerializeField] private Texture2D texture;
    [SerializeField] private float distance = 5;
    [SerializeField] private float deadDistance = 0.2f;
    [SerializeField] private float multiplier = 2f;
    [SerializeField] private float respawningTime = 5f;

    private Camera _playerCamera;
    private GlitchEffect _glitchEffect;
    private Transform _thisObjectTransform;

    private float _defaultGlitchIntencity;
    private float _defaultFlipIntencity;
    private float _defaultColorIntencity;

    private bool _playerNear;

    private int health = 100;

    private void Awake()
    {
        _thisObjectTransform = transform;
    }

    private void Start()
    {
        _playerCamera = Camera.main;
        _glitchEffect = _playerCamera.GetComponent<GlitchEffect>();

        _defaultGlitchIntencity = _glitchEffect.intensity;
        _defaultFlipIntencity = _glitchEffect.flipIntensity;
        _defaultColorIntencity = _glitchEffect.colorIntensity;
    }

    public void GetDamage(int damage)
    {
        if (damage >= health)
        {
            StartCoroutine(SpawningCoroutine());
            gameObject.SetActive(false);
        }
        else health -= damage;
    }

    private IEnumerator SpawningCoroutine()
    {
        yield return new WaitForSeconds(respawningTime);
        health = 100;
        dollSpawner.ActivateDoll();
    }

    private void FixedUpdate()
    {
        navmeshAgent.SetDestination(playerTransform.position);
        float currentDistance = Vector3.Distance(_thisObjectTransform.position, playerTransform.position);

        if (currentDistance <= distance)
        {
            if (currentDistance <= deadDistance)
            {
                playerDeath.Die();
                vignette.color = Color.clear;
                enabled = false;
                return;
            }

            if (!_playerNear)
            {
                hummmAudioSource.Play();
                _playerNear = true;
                cameraShaking.StartShaking();
            }

            float inversedDistance = 1 - (currentDistance / distance);
            ManageSoundVolume(inversedDistance);
        }
        else
        {
            if (_playerNear)
            {
                textureCleaner.ClearTexture(texture);
                _playerNear = false;
                hummmAudioSource.Stop();
                cameraShaking.StopShaking();
            }
        }
    }

    private void ManageSoundVolume(float inversedDistance)
    {
        _playerCamera.fieldOfView = 60 + inversedDistance * 80;
        hummmAudioSource.volume = inversedDistance * multiplier;
        audioManager.SetVolume("everythingVolume", inversedDistance * -25);

        _glitchEffect.intensity = _defaultGlitchIntencity + inversedDistance * multiplier * (1 - _defaultGlitchIntencity);
        _glitchEffect.flipIntensity = _defaultFlipIntencity + inversedDistance * multiplier * (1 - _defaultFlipIntencity);
        _glitchEffect.colorIntensity = _defaultColorIntencity + inversedDistance * multiplier * (1 - _defaultColorIntencity);

        vignette.color = new Color(0, 0, 0, inversedDistance);

        cameraShaking.ShakeIntencity = inversedDistance;
    }
}
