using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRange : MonoBehaviour
{
    [SerializeField] private AnimationStateController _playerAnimation;

    private void OnTriggerEnter(Collider other)
    {
        var player = NewPlayer.Instance.GetComponent<NewPlayer>();
        if (player)
        {
            if (NewPlayer.Instance.playerPower>=15)
            {
                _playerAnimation.PlayerWall();
            }
            
        }
    }


}
