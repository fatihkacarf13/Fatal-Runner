using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : ScaleControl
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
        var player = other.GetComponent<NewPlayer>();
        if (player)
        {

            fight = true;

            if (transform.localScale.y > player.transform.localScale.y)
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

    public void LateUpdate()
    {
        if (transform.localScale.y<= 0.25f)
        {

            fight = false;
            _moveZ.isMove = false;
            Destroy(gameObject);
        }
        if (transform.localScale.y <= 0.25f)
        {
            
            _player.NextLevel();
            System.Threading.Thread.Sleep(500);
        }

    }

}
