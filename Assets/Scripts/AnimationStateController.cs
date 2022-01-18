using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{

    [SerializeField] private Animator _animator;



    [Button]
    public void Run()
    {
        _animator.SetTrigger("isRunning");
    }

    [Button]
    public void Punch()
    {
        _animator.SetTrigger("isPunching");
    }

    [Button]
    public void Hitted()
    {
        _animator.SetTrigger("isHitted");
    }

    [Button]
    public void Idle()
    {
        _animator.SetTrigger("isIdle");
    }

    [Button]
    public void PlayerDeath()
    {
        _animator.SetTrigger("isPlayerDeath");
    }

    [Button]
    public void PlayerWin()
    {
        _animator.SetTrigger("isWin");
    }


}