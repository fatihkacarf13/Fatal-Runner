using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : ScaleControl
{
    [SerializeField] private NewPlayer _player;
    [SerializeField] private MoveZ _moveZ;

    bool fight = false;
    bool fightResult;



    private void Awake()
    {
        _moveZ = FindObjectOfType<MoveZ>();
        _player = FindObjectOfType<NewPlayer>();
    }

    public void OnTriggerStay(Collider other)
    {
        var player = other.GetComponent<NewPlayer>();
        if (player)
        {

            fight = true;

            if (fight)
            {
                ScaleD();
                System.Threading.Thread.Sleep(10);
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
