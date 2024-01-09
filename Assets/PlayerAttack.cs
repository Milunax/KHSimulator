using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] InputActionReference _attack;

    public InputActionReference Attack { get => _attack; set => _attack = value; }

    // Start is called before the first frame update
    void Start()
    {
        _attack.action.started += StartAttack;
    }

    private void OnDestroy()
    {
        _attack.action.started -= StartAttack;
    }

    private void StartAttack(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    private void TakeDamage()
    {

    }
}
