using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    public static PlayerPunch Instance;
    [SerializeField] private AnimationStateController _animStateController;
    [SerializeField] private BossAnimations _bossanimStateController;
    public bool death = false;

    public void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !death)
        {
            EnablePunch();
        }
        if (death)
        {
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BossPunch"))
        {
            NewPlayer.Instance.playerHealt -= 10;
            _animStateController.Hitted();
            if (NewPlayer.Instance.playerHealt <= 0)
            {
                _animStateController.PlayerDeath();
                death = true;
                _bossanimStateController.BossWin();
                StartCoroutine(WaitForDance(3.25f));
            }
        }
    }

    private void EnablePunch()
    {
        if (Drag.Instance.enabled == false)
        {
            _animStateController.Punch();
        }
    }

    private IEnumerator WaitForDance(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        NewPlayer.Instance.RestartLevel();
    }


}
