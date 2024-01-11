using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IHealth
{
    bool IsDead { get; }
    void TakeDamage(int damages);
    void Regen(int heal);
    void AddMaxHealth(int maxHealthToAdd);
}

public class HealthProxy : MonoBehaviour, IHealth
{
    [SerializeField] EntityHealth _healthComponent;

    public bool IsDead => _healthComponent.IsDead;

    public void AddMaxHealth(int maxHealthToAdd)
    {
        _healthComponent.AddMaxHealth(maxHealthToAdd);
    }

    public void Regen(int heal)
    {
        _healthComponent.Regen(heal);
    }

    public void TakeDamage(int damages)
    {
        _healthComponent.TakeDamage(damages);
    }
}
