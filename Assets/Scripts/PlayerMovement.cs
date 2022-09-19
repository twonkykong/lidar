using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AudioSource footstepAudioSource;
    [SerializeField] private AudioClip[] footstepAudioClips;
    [SerializeField] private float footstepInterval = 0.2f;
    [SerializeField] private float gravity = 9.81f;
    public float Speed = 1f;

    private InputMaster _inputMaster;
    private InputAction _movementAxis;
    private CharacterController _characterController;
    private Transform _thisObjectTransform;
    private Vector3 _velocity;

    private Coroutine _footstepSoundCoroutine;

    private void Awake()
    {
        _inputMaster = new InputMaster();

        _movementAxis = _inputMaster.Inputs.Movement;
        _movementAxis.started += _ => PlayFootstepSound();
        _movementAxis.canceled += _ => StopFootstepSound();

        _characterController = GetComponent<CharacterController>();
        _thisObjectTransform = transform;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayFootstepSound()
    {
        if (_footstepSoundCoroutine == null) _footstepSoundCoroutine = StartCoroutine(PlayFootstepSoundCoroutine());
    }

    private void StopFootstepSound()
    {
        StopCoroutine(_footstepSoundCoroutine);
        _footstepSoundCoroutine = null;
    }

    private void Move()
    {
        _velocity.x = _movementAxis.ReadValue<Vector2>().x;
        _velocity.z = _movementAxis.ReadValue<Vector2>().y;
        if (_characterController.isGrounded) _velocity.y = 0;
        else _velocity.y = -gravity;

        _characterController.Move((_thisObjectTransform.rotation * _velocity) * Speed);
    }

    private IEnumerator PlayFootstepSoundCoroutine()
    {
        while (true)
        {
            footstepAudioSource.PlayOneShot(footstepAudioClips[Random.Range(0, footstepAudioClips.Length)]);
            yield return new WaitForSeconds(footstepInterval);
        }
    }

    private void OnEnable()
    {
        _inputMaster.Enable();
    }

    private void OnDisable()
    {
        _movementAxis.started -= _ => PlayFootstepSound();
        _movementAxis.canceled -= _ => StopFootstepSound();
        _inputMaster.Disable();
    }
}
