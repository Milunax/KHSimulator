using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimatorBinding : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMoveScript;
    [SerializeField] private PlayerAttack _playerAttackScript;
    [SerializeField] private Animator _animator;

    private Coroutine _attackCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        _playerMoveScript.Move.action.started += MoveStart;
        _playerMoveScript.Move.action.canceled += MoveStop;

        _playerAttackScript.Attack.action.started += AttackStart;
    }

    private void MoveStart(InputAction.CallbackContext obj)
    {
        _animator.SetBool("Walking", true);
    }

    private void MoveStop(InputAction.CallbackContext context)
    {
        _animator.SetBool("Walking", false);
    }
  
    private void AttackStart(InputAction.CallbackContext obj)
    {
        if(_attackCoroutine == null)
        {
            _attackCoroutine = StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        _animator.SetTrigger("Attack");

        yield return new WaitForSeconds(0.5f);

        _attackCoroutine = null;

        yield break;
    }

    private void OnDestroy()
    {
        _playerMoveScript.Move.action.started -= MoveStart;
        _playerMoveScript.Move.action.started -= MoveStop;

        _playerAttackScript.Attack.action.started -= AttackStart;
    }
}
