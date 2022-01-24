using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightLineControl : MonoBehaviour
{
    public BoxCollider bossHitBox;
    public GameObject playerHealth;
    public GameObject bossHealth;
    public static FightLineControl Instance;
    public bool bossFight = false;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var player = NewPlayer.Instance.GetComponent<NewPlayer>();
         
        if (player)
        {
            bossFight = true;
            bossHitBox.enabled = true;
            MoveZ.Instance.isMove = false;
            Drag.Instance.enabled = false;
            bossHealth.SetActive(true);
            playerHealth.SetActive(true); 
        }
    }
}
