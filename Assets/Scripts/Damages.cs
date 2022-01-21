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
        if (NewPlayer.Instance.playerPower >= 0)
        {
            playerDamage = 10;
            bossDagame = 25;
        }
        if (NewPlayer.Instance.playerPower > 24 )
        {
            playerDamage = 15;
            bossDagame = 22;
        }
        if (NewPlayer.Instance.playerPower > 49 )
        {
            playerDamage = 17;
            bossDagame = 21;
        }
        if (NewPlayer.Instance.playerPower > 74 )
        {
            playerDamage = 25;
            bossDagame = 15;
        }
        if (NewPlayer.Instance.playerPower >= 100)
        {
            playerDamage = 34;
            bossDagame = 15;
        }

    }


}
