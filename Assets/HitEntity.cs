using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEntity : MonoBehaviour
{
    [SerializeField] private int _damages;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IHealth health))
        {
            health.TakeDamage(_damages);
        }
    }
}
