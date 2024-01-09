using Cinemachine;
using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] InputActionReference _move;
    
    [SerializeField] float _speed;
    [SerializeField] float _rotationSpeed;

    // Event pour les dev
    public event Action OnStartMove;
    public event Action OnStopMove;
    public event Action<int> OnHealthUpdate;

    // Event pour les GD
    [SerializeField] UnityEvent _onEvent;
    [SerializeField] UnityEvent _onEventPost;

    public Vector2 JoystickDirection { get; private set; }
    private Vector2 _rotationDirection;
    Coroutine MovementRoutine { get; set; }
    public InputActionReference Move { get => _move; }

    private void Start()
    {
        _move.action.started += StartMove;
        _move.action.performed += UpdateMove;
        _move.action.canceled += StopMove;    
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + JoystickDirection.x * _speed * Time.deltaTime,
                                        transform.position.y,
                                        transform.position.z + JoystickDirection.y * _speed * Time.deltaTime);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, Mathf.Rad2Deg * Mathf.Atan2(_rotationDirection.x, _rotationDirection.y), 0), _rotationSpeed * Time.deltaTime);
    }
    private void OnDestroy()
    {
        _move.action.started -= StartMove;
        _move.action.performed -= UpdateMove;
        _move.action.canceled -= StopMove;
    }

    private void StartMove(InputAction.CallbackContext obj)
    {
        OnStartMove?.Invoke();
    }

    private void UpdateMove(InputAction.CallbackContext obj)
    {
        JoystickDirection = obj.ReadValue<Vector2>();
        _rotationDirection = JoystickDirection;
    }

    private void StopMove(InputAction.CallbackContext obj)
    {
        JoystickDirection = obj.ReadValue<Vector2>();
        OnStopMove?.Invoke();
    }
}
