using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    [SerializeField] Slider _slider;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] EntityHealth _playerHealth;

    int CachedMaxHealth { get; set; }

    private void Start()
    {
        CachedMaxHealth = _playerHealth.MaxHealth;
        UpdateSlider(_playerHealth.CurrentHealth);
        _playerHealth.OnTakeDamages += _playerHealth_UpdateHealthSlider;
        _playerHealth.OnHeal += _playerHealth_UpdateHealthSlider;
    }

    private void _playerHealth_UpdateHealthSlider()
    {
        CachedMaxHealth = _playerHealth.MaxHealth;
        UpdateSlider(_playerHealth.CurrentHealth);
    }

    void UpdateSlider(int newHealthValue)
    {
        _slider.value = newHealthValue;
        _text.text = $"{newHealthValue} / {CachedMaxHealth}";
    }

}
