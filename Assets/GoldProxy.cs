using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IGold
{
    void AddGold(int goldToAdd);
}

public class GoldProxy : MonoBehaviour, IGold
{
    [SerializeField] private EntityGold _goldComponent;

    public void AddGold(int goldToAdd)
    {
        _goldComponent.AddGold(goldToAdd);
    }
}
