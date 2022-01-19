using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    private Image _healthBar;
    public float currentHealth;
    private float _maxHealth = 40f;

    void Start()
    {
        _healthBar = GetComponent<Image>();
    }

    void Update()
    {
        currentHealth = Boss.Instance.bossHealt;
        _healthBar.fillAmount = currentHealth / _maxHealth;
    }
}
