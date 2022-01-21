using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightLineControl : MonoBehaviour
{

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
