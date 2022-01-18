using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    [SerializeField] private Drag _drag;
    [SerializeField] private NewPlayer _player;
    [SerializeField] private AnimationStateController _animStateController;
    private bool death = false;
    Boss boss;

    void Start()
    {
        _player = FindObjectOfType<NewPlayer>();
        _drag = _player.GetComponent<Drag>();
        boss = FindObjectOfType<Boss>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)&& !death)
        {
            EnablePunch();
        }
        if (boss.bossHealt==0)
        {
            death = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BossPunch"))
        {
            _player.playerHealt -= 10;
            _animStateController.Hitted();
            if (_player.playerHealt <= 0)
            {
                _animStateController.PlayerDeath();
                death = true;

            }
          

        }

    }

    private void EnablePunch()
    {
        if (_drag.enabled==false)
        {
            _animStateController.Punch();
        }
    }
}
