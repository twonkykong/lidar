using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Transform head;
    [SerializeField] private Transform body;
    [SerializeField] private float sensitivity = 10;

    private InputMaster _inputMaster;
    private float _xLook, _yLook;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _inputMaster = new InputMaster();
    }

    private Vector2 GetLookAxis()
    {
        float x = _inputMaster.Inputs.LookX.ReadValue<float>();
        float y = _inputMaster.Inputs.LookY.ReadValue<float>();

        return new Vector2(x, y);
    }

    private void FixedUpdate()
    {
        Look();
    }

    private void Look()
    {
        Vector2 lookAxis = GetLookAxis();
        _xLook += lookAxis.x * sensitivity;
        _yLook += lookAxis.y * sensitivity;

        _yLook = Mathf.Clamp(_yLook, -90, 90);
        if (_xLook > 359) _xLook -= 360;
        else if (_xLook < 0) _xLook += 360;

        body.localEulerAngles = new Vector3(0, _xLook, 0);
        head.localEulerAngles = new Vector3(-_yLook, 0, 0);
    }

    private void OnEnable()
    {
        _inputMaster.Enable();
    }

    private void OnDestroy()
    {
        _inputMaster.Disable();
    }
}
