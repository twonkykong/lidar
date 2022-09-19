using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using DG.Tweening;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioSource loadedLevelAudioSource;
    [SerializeField] private bool doTurnOnAtStart = true;

    private void Start()
    {
        loadedLevelAudioSource.Play();
        if (doTurnOnAtStart) TurnOn();
    }

    public void TurnOff(float duration = 0f)
    {
        audioMixer.GetFloat("hummmVolume", out float hummVolume);
        DOTween.To(() => hummVolume, x => audioMixer.SetFloat("hummmVolume", x), -80f, duration);

        audioMixer.GetFloat("everythingVolume", out float everythingVolume);
        DOTween.To(() => everythingVolume, x => audioMixer.SetFloat("everythingVolume", x), -80f, duration);
    }

    public void TurnOn(float duration = 0f)
    {
        audioMixer.GetFloat("hummmVolume", out float hummVolume);
        DOTween.To(() => hummVolume, x => audioMixer.SetFloat("hummmVolume", x), 0, duration);

        audioMixer.GetFloat("everythingVolume", out float everythingVolume);
        DOTween.To(() => everythingVolume, x => audioMixer.SetFloat("everythingVolume", x), 0, duration);
    }

    public void SetVolume(string volumeName, float value)
    {
        audioMixer.SetFloat(volumeName, value);
    }
}
