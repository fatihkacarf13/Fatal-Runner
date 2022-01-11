using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    [SerializeField]private MoveZ _moveZ;

    private void Awake()
    {
      _moveZ = FindObjectOfType<MoveZ>();

    }
    private void OnTriggerEnter(Collider other)
    {

        var player = other.GetComponent<NewPlayer>();
        if (player)
        {
            _moveZ.isMove = false;

            if (player.transform.localScale.y >= transform.localScale.y)
            {
                player.Score += 20;
                Destroy(gameObject);
                player.NextLevel();
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
