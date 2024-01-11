using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] InputActionReference _attack;
    [SerializeField] BoxCollider _attackCollider;

    public InputActionReference Attack { get => _attack; set => _attack = value; }

    // Start is called before the first frame update
    void Start()
    {
        _attack.action.started += AttackColliderEnable;
        _attack.action.canceled += AttackColliderDisable;
    }

    private void AttackColliderEnable(InputAction.CallbackContext obj)
    {
        _attackCollider.enabled = true;
    }

    private void AttackColliderDisable(InputAction.CallbackContext context)
    {
        _attackCollider.enabled = false;
    }

    private void OnDestroy()
    {
        _attack.action.started -= AttackColliderEnable;
        _attack.action.canceled -= AttackColliderDisable;
    }

}
