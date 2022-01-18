using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    private Image _healthBar;
    public float currentHealth ;
    private float _maxHealth ;
    NewPlayer player;

    void Start()
    {
        _healthBar = GetComponent<Image>();
        player = FindObjectOfType<NewPlayer>();
        _maxHealth = player.playerHealt;


    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = player.playerHealt;
        _healthBar.fillAmount = currentHealth / _maxHealth;
    }
}
