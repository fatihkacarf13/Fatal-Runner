using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : ScaleControl
{
    [SerializeField] private NewPlayer _player;
    [SerializeField] private MoveZ _moveZ;

    bool fight = false;


    private void Awake()
    {
        _moveZ = FindObjectOfType<MoveZ>();
        _player = FindObjectOfType<NewPlayer>();

    }

    public void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Boss"))
        {

            fight = true;

            if (fight)
            {
                ScaleD();
                System.Threading.Thread.Sleep(10);
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