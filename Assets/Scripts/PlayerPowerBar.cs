using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPowerBar : MonoBehaviour
{
    private Image _powerBar;
    public float currentPower;
    public static PlayerPowerBar Instance;

    private float _maxHealth = 100f;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
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
