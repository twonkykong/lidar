using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private AudioSource additionalAudioSource;
    [SerializeField] private AudioSource ambienceAudioSource;
    [SerializeField] private AudioClip playAudioClip;
    [SerializeField] private MenuLidarScanner menuLidarScanner;
    [SerializeField] private Image hintHolder;
    [SerializeField] private Image blackScreen;
    [SerializeField] private TextMeshProUGUI hint;

    private InputMaster _inputMaster;
    private bool _canAnyKey;

    private DG.Tweening.Core.TweenerCore<float, float, DG.Tweening.Plugins.Options.FloatOptions> ambienceSoundTween;

    private void Awake()
    {
        _inputMaster = new InputMaster();
        _inputMaster.UI.Anykey.performed += _ => OnAnyKey();
    }

    private void Start()
    {
        ambienceSoundTween = DOTween.To(() => ambienceAudioSource.volume, x => ambienceAudioSource.volume = x, 1f, 25f);
        blackScreen.DOFade(0f, 4f).OnComplete(() => _canAnyKey = true);

        menuLidarScanner.Scan();

        Invoke("ShowHint", 30f);
    }

    private void ShowHint()
    {
        hint.DOFade(0.8f, 0.1f);
        hintHolder.DOFade(0.4f, 0.1f);
    }

    private void OnAnyKey()
    {
        if (!_canAnyKey) return;
        StartCoroutine(StartPlayCoroutine());
        _canAnyKey = false;
    }

    private IEnumerator StartPlayCoroutine()
    {
        ambienceSoundTween.Kill();
        blackScreen.color = Color.black;
        additionalAudioSource.PlayOneShot(playAudioClip);
        ambienceAudioSource.volume = 0;
        yield return new WaitForSeconds(4);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
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
