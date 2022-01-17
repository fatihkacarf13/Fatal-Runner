using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        var boss = other.GetComponent<Boss>();
        if (boss)
        {
            boss.bossHealt -= 10;
        }
    }
}
