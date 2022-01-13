using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : ScaleControl
{
    [SerializeField] private MoveZ _moveZ;
    bool fight = false;
    bool fightResult;


    private void Awake()
    {
        _moveZ = FindObjectOfType<MoveZ>();

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

            }
            if (fightResult && fight)
            {
                ScaleD();
                if (other.transform.localScale.y <= 0)
                {
                    fight = false;
                    _moveZ.isMove = false;
                }
            }
        }

    }



}
