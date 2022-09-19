using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FirstExploreSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private Camera camera;
    private InputMaster _inputMaster;

    private void Awake()
    {
        _inputMaster = new InputMaster();
        _inputMaster.Inputs.Usegun.started += _ => Explore();
    }

    private void Start()
    {
        camera = Camera.main;
        audioManager.TurnOff();
    }

    private void Explore()
    {
        DOTween.To(() => camera.fieldOfView, x => camera.fieldOfView = x, 70, 0.3f).OnComplete(() =>
            DOTween.To(() => camera.fieldOfView, x => camera.fieldOfView = x, 60, 2f));

        audioSource.Play();
        _inputMaster.Inputs.Usegun.started -= _ => Explore();
        StartCoroutine(TurnOnSounds());
        enabled = false;
    }

    private IEnumerator TurnOnSounds()
    {
        yield return new WaitForSeconds(2f);
        audioManager.TurnOn(5f);
    }

    private void OnEnable()
    {
        _inputMaster.Enable();
    }

    private void OnDisable()
    {
        _inputMaster.Disable();
    }
}
