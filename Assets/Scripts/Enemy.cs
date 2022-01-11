using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        var player = other.GetComponent<NewPlayer>();
        if (player)
        {

            player.Score = 0;
            Destroy(player.gameObject);
            player.RestartLevel();

        }


    }
}
