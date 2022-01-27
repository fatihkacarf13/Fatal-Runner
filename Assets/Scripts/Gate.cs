using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : BaseUIColorable
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<NewPlayer>();
        if (player)
        {
            player.SetColor(GetColor());
            Destroy(gameObject);
        }
    }

}
