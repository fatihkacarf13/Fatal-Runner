using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        var player = other.GetComponent<NewPlayer>();
        if (player)
        {
            if (player.transform.localScale.y * 2 > transform.localScale.y)
            {
                player.Score += 10;
                Destroy(gameObject);

            }
            else
            {
                player.Score = 0;
                Destroy(player.gameObject);
                player.RestartLevel();
            }
        }

        
    }
}
