using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightLineControl : MonoBehaviour
{
    public BoxCollider bossHitBox;
    public GameObject playerHealth;
    public GameObject bossHealth;
    public GameObject tapToFight;
    public static FightLineControl Instance;
    public bool bossFight = false;
    private Vector3 fightPosition;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (bossFight)
        {
            var player = NewPlayer.Instance;
            fightPosition = new Vector3(0, player.transform.position.y, player.transform.position.z);
            player.transform.position = Vector3.Lerp(player.transform.position, fightPosition, Time.deltaTime * 10);
        }
        if (PlayerPunch.Instance.death)
        {
            tapToFight.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       var newplayer = other.GetComponent<NewPlayer>();
         
        if (newplayer)
        {
            bossFight = true;
            bossHitBox.enabled = true;
            Debug.Log("hitbox enabled");
            MoveZ.Instance.isMove = false;
            Drag.Instance.enabled = false;
            bossHealth.SetActive(true);
            playerHealth.SetActive(true);
            tapToFight.SetActive(true);
        }
    }
}
