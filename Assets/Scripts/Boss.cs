using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int bossHealt = 40;

    [SerializeField] private BossAnimations _bossanimStateController;

    //public void Update()
    //{
    //    Debug.Log(bossHealt);
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerPunch"))
        {
            if (bossHealt>10)
            {
                _bossanimStateController.BossHitted();
                 HittedAndHit();
                
            }
            if (bossHealt<=10)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * 10);
                _bossanimStateController.BossDeath();
                
            }
           
        }
        
    }

    public IEnumerator HittedAndHit()
    {
        
        yield return new WaitForSeconds(1.5f);
        _bossanimStateController.BossPunch();
    }

    

}
