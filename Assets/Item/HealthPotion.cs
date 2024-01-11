using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    [SerializeField] private int _heal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IHealth health))
        {
            health.Regen(_heal);
        }
    }
}
