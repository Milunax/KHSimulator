using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityGold : MonoBehaviour, IGold
{
    [ShowNativeProperty] public int Golds { get; private set; }
    
    public event Action OnAddGold;

    public void AddGold(int goldToAdd)
    {
        Golds += goldToAdd;
        OnAddGold?.Invoke();
    }
}
