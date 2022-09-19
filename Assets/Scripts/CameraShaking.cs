using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaking : MonoBehaviour
{
    [Range(0, 1)]
    public float ShakeIntencity;
    [SerializeField] private float shakeInterval = 0.1f;

    private Transform _thisObjectTransform;
    private Vector3 _mainLocalPosition;

    private Coroutine _shakingCoroutine;

    private void Awake()
    {
        _thisObjectTransform = transform;
        _mainLocalPosition = _thisObjectTransform.localPosition;
    }

    public void StartShaking()
    {
        if (_shakingCoroutine == null)
        {
            _shakingCoroutine = StartCoroutine(ShakingCoroutine());
        }
    }

    public void StopShaking()
    {
        if (_shakingCoroutine != null)
        {
            StopCoroutine(_shakingCoroutine);
            _shakingCoroutine = null;
        }
        _thisObjectTransform.localPosition = _mainLocalPosition;
    }

    private IEnumerator ShakingCoroutine()
    {
        while (true)
        {
            _thisObjectTransform.localPosition = _mainLocalPosition + new Vector3(Random.Range(-ShakeIntencity/10, shakeInterval),
                Random.Range(-ShakeIntencity/10, shakeInterval),
                Random.Range(-ShakeIntencity/10, shakeInterval));

            yield return new WaitForSeconds(shakeInterval);
        }
    }
}
