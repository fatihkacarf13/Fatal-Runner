using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall : MonoBehaviour
{
    [SerializeField] private AnimationStateController _animStateController;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (NewPlayer.Instance.playerPower < 14)
            {
                _animStateController.PlayerDeath();
                PlayerPunch.Instance.death = true;
                MoveZ.Instance.isMove = false;
                Drag.Instance.enabled = false;
                StartCoroutine(WaitForDeath(3.25f));
            }
        }
       
        
    }

    private IEnumerator WaitForDeath(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        NewPlayer.Instance.RestartLevel();
    }


}
