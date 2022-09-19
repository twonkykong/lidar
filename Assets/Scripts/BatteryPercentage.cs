using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class BatteryPercentage : MonoBehaviour
{
    //[SerializeField] private Camera camera;
    //[SerializeField] private MonoBehaviour[] components;
    //[SerializeField] private AudioSource ambienceSource;
    //[SerializeField] private AudioClip zeroPercentAudioClip;

    [SerializeField] private PlayerDeath playerDeath;
    [SerializeField] private Slider percentageSlider;
    [SerializeField] private Image blackScreen;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip energyWasteAudioClip;
    [SerializeField] private Animation wasteEnergyAnim;
    [SerializeField] private TextMeshProUGUI _percentageText;
    [SerializeField] private bool _doWasteEnergy;
    [SerializeField] private float wastingInterval;

    private Coroutine _wasteEnergyCoroutine;

    private int _batteryEnergy = 100;

    public int BatteryEnergy
    {
        get { return _batteryEnergy; }
    }

    public void MultiplyInterval(float multiplier)
    {
        wastingInterval *= multiplier;
        if (multiplier < 1 && _doWasteEnergy)
        {
            StopCoroutine(_wasteEnergyCoroutine);
            _wasteEnergyCoroutine = StartCoroutine(WasteEnergyCoroutine());
        }
    }

    private void Awake()
    {
        if (_doWasteEnergy) _wasteEnergyCoroutine = StartCoroutine(WasteEnergyCoroutine());
    }

    private IEnumerator WasteEnergyCoroutine()
    {
        yield return new WaitForSeconds(wastingInterval);
        WasteEnergy(1);
    }

    public void WasteEnergy(int energy)
    {
        _batteryEnergy -= energy;
        if (_batteryEnergy <= 0)
        {
            StopCoroutine(_wasteEnergyCoroutine);
            audioSource.Stop();
            playerDeath.Die();
            //StartCoroutine(ZeroPercentageCoroutine());
        }
        else
        {
            wasteEnergyAnim.Stop();
            wasteEnergyAnim.Play();
            audioSource.PlayOneShot(energyWasteAudioClip, Random.Range(0.75f, 1));

            if (_batteryEnergy % 25 == 0) blackScreen.color = new Color(0, 0, 0, (100f - _batteryEnergy)/100f);

            if (_doWasteEnergy)
            {
                StopCoroutine(_wasteEnergyCoroutine);
                _wasteEnergyCoroutine = StartCoroutine(WasteEnergyCoroutine());
            }
        }

        _percentageText.text = _batteryEnergy.ToString() + "%";
        percentageSlider.value = _batteryEnergy;
    }

/*    private IEnumerator ZeroPercentageCoroutine()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(zeroPercentAudioClip);
        foreach (MonoBehaviour component in components) component.enabled = false;
        yield return new WaitForSeconds(5f);
        blackScreen.DOFade(1f, 2.5f);
        DOTween.To(() => camera.fieldOfView, x => camera.fieldOfView = x, 70f, 2.5f).SetEase(Ease.Linear);
        //camera.transform.DOLocalRotate(camera.transform.localEulerAngles + Vector3.forward * 10f, 2.5f).SetEase(Ease.Linear);
    }
*/
}
