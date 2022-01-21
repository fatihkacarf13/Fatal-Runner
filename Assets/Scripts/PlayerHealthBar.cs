using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    private Image _healthBar;
    public float currentHealth;
    private float _maxHealth = 100;

    void Start()
    {
        _healthBar = GetComponent<Image>();

    }

    void Update()
    {
        currentHealth = NewPlayer.Instance.playerHealt;
        _healthBar.fillAmount = currentHealth / _maxHealth;
    }
}
