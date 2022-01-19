using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Boss : MonoBehaviour
{   
    public int bossHealt = 40;
    public static Boss Instance;

    public void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
    }
    private void Update()
    {
        if (PlayerPunch.Instance.death)
        {
            GetComponent<BoxCollider>().enabled = false;
        }
    }
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
                PlayerPunch.Instance.death = true;
                StartCoroutine(WaitForDance(3.25f));
            }
           
        }
        
    }

    private IEnumerator WaitForDance(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        NewPlayer.Instance.NextLevel();
    }





}
