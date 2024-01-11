using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour, IHealth
{

    [SerializeField] int _maxHealth;

    public event Action OnTakeDamages;
    public event Action OnHeal;

    [ShowNativeProperty] public int CurrentHealth { get; private set; }

    public bool IsDead => throw new System.NotImplementedException();

    public int MaxHealth { get => _maxHealth; }

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damages)
    {
        CurrentHealth -= damages;
        OnTakeDamages?.Invoke();
    }

    public void Regen(int heal)
    {
        if(CurrentHealth < _maxHealth)
        {
            CurrentHealth += heal;
            if(CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
            OnHeal?.Invoke();
        }
    }

    public void AddMaxHealth(int maxHealthToAdd)
    {
        _maxHealth += maxHealthToAdd;
        Regen(maxHealthToAdd);
    }
}
