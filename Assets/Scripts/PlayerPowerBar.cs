using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPowerBar : MonoBehaviour
{
    private Image _powerBar;
    public float currentPower;
    private float _maxHealth = 100f;

    void Start()
    {
        _powerBar = GetComponent<Image>();

    }

    void Update()
    {
        currentPower = NewPlayer.Instance.playerPower;
        _powerBar.fillAmount = currentPower / _maxHealth;
    }
}
