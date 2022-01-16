using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightLineControl : MonoBehaviour
{
    [SerializeField] private MoveZ _moveZ;
    [SerializeField] private NewPlayer _player;
    void Awake()
    {
        _moveZ = FindObjectOfType<MoveZ>();
        _player = FindObjectOfType<NewPlayer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<NewPlayer>();
        if (player)
        {
            _moveZ.isMove = false;
           
        }
    }
}
