using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<NewPlayer>();
        if (player)
        {
            player.playerHealt -= 10;
        }
    }
}
