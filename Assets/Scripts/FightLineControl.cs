using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightLineControl : MonoBehaviour
{
    //[SerializeField] private NewPlayer _player;
    //void Awake()
    //{
    //    _player = FindObjectOfType<NewPlayer>();
    //}

    private void OnTriggerEnter(Collider other)
    {
        var player = NewPlayer.Instance.GetComponent<NewPlayer>();
        if (player)
        {
            MoveZ.Instance.isMove = false;
            Drag.Instance.enabled = false;
        }
    }
}
