using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform _cameraTransform;
    private Transform _thisObjectTransform;

    private void Start()
    {
        _cameraTransform = Camera.main.transform;
        _thisObjectTransform = transform;
    }

    private void FixedUpdate()
    {
        _thisObjectTransform.rotation = _cameraTransform.rotation;
    }
}
