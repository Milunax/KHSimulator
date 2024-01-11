using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gold : Item
{
    [SerializeField] private int _goldToAdd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IGold gold))
        {
            gold.AddGold(_goldToAdd);
        }
    }
}
