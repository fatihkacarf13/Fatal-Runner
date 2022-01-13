using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : ScaleControl
{
    [SerializeField] private NewPlayer _player;
    [SerializeField] private MoveZ _moveZ;

    bool fight = false;
    private float _healt;
    public bool win = false;



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

    public void Update()
    {
        _healt = transform.localScale.y;
        if (_healt<= 0.25f)
        {

            fight = false;
            _moveZ.isMove = false;
            Destroy(gameObject);
            win = true;


        }
        if (win)
        {
            System.Threading.Thread.Sleep(1000);
            _player.NextLevel();
            
        }

    }

}
