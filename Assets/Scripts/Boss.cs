using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int bossHealt = 40;

    [SerializeField] private BossAnimations _bossanimStateController;

    public void Update()
    {
        Debug.Log(bossHealt);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerPunch"))
        {
            if (bossHealt>10)
            {
                _bossanimStateController.BossHitted();

            }
            if (bossHealt<=10)
            {
                _bossanimStateController.BossDeath();
            }
           
        }
        
    }

    


}
