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
            StartCoroutine(WaitForDeath());
            NewPlayer.Instance.GetComponent<CapsuleCollider>().enabled = false;

        }


    }

    private IEnumerator WaitForDeath()
    {
        float waitTime = 3f;
        NewPlayer.Instance.animStateController.PlayerDeath();
        PlayerPunch.Instance.death = true;
        MoveZ.Instance.isMove = false;
        Drag.Instance.enabled = false;
        yield return new WaitForSeconds(waitTime);
        NewPlayer.Instance.RestartLevel();
    }



}
