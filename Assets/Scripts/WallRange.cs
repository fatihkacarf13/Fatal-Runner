using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = NewPlayer.Instance.GetComponent<NewPlayer>();
        if (player)
        {
            Drag.Instance.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var player = NewPlayer.Instance.GetComponent<NewPlayer>();
        if (player)
        {
            Drag.Instance.enabled = true;
        }
    }
}
