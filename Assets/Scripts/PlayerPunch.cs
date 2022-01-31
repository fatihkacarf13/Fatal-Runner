using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    public static PlayerPunch Instance;
    [SerializeField] private AnimationStateController _animStateController;
    [SerializeField] private BossAnimations _bossanimStateController;
    public bool death = false;
    private bool _criticHealth = false;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && !death && !_criticHealth)
        {
            EnablePunch();
        }
        if (death)
        {
            GetComponent<BoxCollider>().enabled = false;
        }

        if (Boss.Instance.bossHealt <= Damages.Instance.playerDamage&& !_criticHealth)
        {
            _animStateController.gameObject.SetActive(false);
            _animStateController.gameObject.SetActive(true);
            _bossanimStateController.BossIdle();
            _criticHealth = true;
            


        }
        if (_criticHealth)
        {
            SuperPunch();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BossPunch"))
        {
            NewPlayer.Instance.playerHealt -= Damages.Instance.bossDagame;
            _animStateController.Hitted();
            if (NewPlayer.Instance.playerHealt <= 0)
            {
                _animStateController.PlayerDeath();
                death = true;
                _bossanimStateController.BossWin();
                StartCoroutine(WaitForRestart(3.25f));
            }
        }
    }

    private void EnablePunch()
    {
        if (Drag.Instance.enabled == false && !death)
        {
            if (_criticHealth)
            {

                SuperPunch();

            }
            else
            {
                _animStateController.Punch();
            }
            

        }
    }
    private void SuperPunch()
    {
        _animStateController.PlayerSuper();
    }
    private IEnumerator WaitForRestart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        NewPlayer.Instance.RestartLevel();
    }



}
