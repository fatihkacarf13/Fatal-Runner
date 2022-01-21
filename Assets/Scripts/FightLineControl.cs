using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightLineControl : MonoBehaviour
{
    public BoxCollider bossHitBox;
    public GameObject playerHealth;
    public GameObject bossHealth;

    private void OnTriggerEnter(Collider other)
    {
        var player = NewPlayer.Instance.GetComponent<NewPlayer>();
         
        if (player)
        {
            bossHitBox.enabled = true;
            MoveZ.Instance.isMove = false;
            Drag.Instance.enabled = false;
            bossHealth.SetActive(true);
            playerHealth.SetActive(true); 
        }
    }
}
