using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damages : MonoBehaviour
{
    public static Damages Instance;
    public int playerDamage = 10;
    public int bossDagame = 25;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Update()
    {
        PowerToDamage();
    }

    public void PowerToDamage()
    {
        if (SecPlayerPowerBar.Instance.secCurrentPower >= 0&& SecPlayerPowerBar.Instance.secCurrentPower <24)
        {
            playerDamage = 10;
            bossDagame = 25;
        }
        if (SecPlayerPowerBar.Instance.secCurrentPower >=24&& SecPlayerPowerBar.Instance.secCurrentPower <49 )
        {
            playerDamage = 15;
            bossDagame = 20;
        }
        if (SecPlayerPowerBar.Instance.secCurrentPower >= 49 && SecPlayerPowerBar.Instance.secCurrentPower < 74)
        {
            playerDamage = 20;
            bossDagame = 20;
        }
        if (SecPlayerPowerBar.Instance.secCurrentPower >= 74 && SecPlayerPowerBar.Instance.secCurrentPower < 100)
        {
            playerDamage = 25;
            bossDagame = 15;
        }
        if (SecPlayerPowerBar.Instance.secCurrentPower >= 100)
        {
            playerDamage = 35;
            bossDagame = 15;
        }

    }


}
