using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Item
{
    [SerializeField] private int _maxhealthToAdd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IHealth health))
        {
            health.AddMaxHealth(_maxhealthToAdd);
        }
    }
}
