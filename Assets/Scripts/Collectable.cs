using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : BaseColorable
{
    private void OnTriggerEnter(Collider other)
    {
       var player = other.GetComponent<NewPlayer>();
        if (player)
        {
            if (GetColor() == player.GetColor())
            {
                player.ScaleUp();
            }
            else
            {
                player.ScaleDown();
            }
            Destroy(gameObject);
        }
    }
}
