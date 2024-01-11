using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] EntityGold _playerGold;
    // Start is called before the first frame update
    void Start()
    {
        UpdateText(_playerGold.Golds);
        _playerGold.OnAddGold += OnAddGoldUpdateText;
    }

    private void OnAddGoldUpdateText()
    {
        UpdateText(_playerGold.Golds);
    }

    private void UpdateText(int newGoldValue)
    {
        _text.text = $"Gold : {newGoldValue}";
    }
}
