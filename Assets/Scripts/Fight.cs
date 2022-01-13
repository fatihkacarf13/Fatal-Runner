using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : ScaleControl
{
    [SerializeField] private MoveZ _moveZ;
    [SerializeField] private NewPlayer _player;
    bool fight = false;
    bool fightResult;


    private void Awake()
    {
        _moveZ = FindObjectOfType<MoveZ>();
        _player = FindObjectOfType<NewPlayer>();
    }

    public void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Fight"))
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
                System.Threading.Thread.Sleep(5);

            }
            if (fightResult && fight)
            {
                ScaleD();
                System.Threading.Thread.Sleep(5);
                if (transform.localScale.y==0f)
                {
                    fight = false;
                }
            }
            if (transform.localScale.y == 0f)
            {
                fight = false;
            }
        }

    }

    private void LateUpdate()
    {
        if (transform.localScale.y<= 0f)
        {

            fight = false;
            _moveZ.isMove = false;
            Destroy(gameObject);
            System.Threading.Thread.Sleep(500);
            _player.RestartLevel();
        }


    }

}
