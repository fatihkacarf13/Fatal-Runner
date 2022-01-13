using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : ScaleControl
{
    [SerializeField] private NewPlayer _player;
    [SerializeField] private BossHealt _boss;
    [SerializeField] private MoveZ _moveZ;

    bool fight = false;
    bool fightResult;


    private void Awake()
    {
        _moveZ = FindObjectOfType<MoveZ>();
        _player = FindObjectOfType<NewPlayer>();
        _boss = FindObjectOfType<BossHealt>();
    }

    public void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Boss"))
        {

            fight = true;

            if (transform.localScale.y > other.transform.localScale.y)
            {
                fightResult = true;
            }
            else
            {
                fightResult = false;
            }
            if (!fightResult && fight)
            {
                ScaleD();
                System.Threading.Thread.Sleep(10);
            }
            if (fightResult && fight)
            {
                ScaleD();
                System.Threading.Thread.Sleep(10);

            }
            if (transform.localScale.y == 0f)
            {
                fight = false;
            }
        }

    }
    public void FixedUpdate()
    {
        if (transform.localScale.y <= 0.25f)
        {

            fight = false;
            _moveZ.isMove = false;
            Destroy(gameObject);
        }
        if (transform.localScale.y <= 0.25f)
        {
            _player.RestartLevel();
            System.Threading.Thread.Sleep(500);
        }

    }

}