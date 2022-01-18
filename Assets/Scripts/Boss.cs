using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{   
    public int bossHealt = 40;

    [SerializeField] private BossAnimations _bossanimStateController;
    [SerializeField] private AnimationStateController _playerAnimation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerPunch"))
        {
            bossHealt -= 10;
            if (bossHealt>=10)
            {
                _bossanimStateController.BossHitted();
                
            }
            if (bossHealt==0)
            {
                _bossanimStateController.BossDeath();
                _playerAnimation.PlayerWin();
                
            }
           
        }
        
    }

    

}
