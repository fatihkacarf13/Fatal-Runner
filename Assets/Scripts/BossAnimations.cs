using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimations : MonoBehaviour
{
    [SerializeField] private Animator _bossAnimator;


    [Button]
    public void BossPunch()
    {
        _bossAnimator.SetTrigger("isBossPunch");
    }

    [Button]
    public void BossHitted()
    {
        _bossAnimator.SetTrigger("isBossHitted");
    }

    [Button]
    public void BossIdle()
    {
        _bossAnimator.SetTrigger("isBossIdle");
    }

    [Button]
    public void BossDeath()
    {
        _bossAnimator.SetTrigger("isBossDeath");
    }

    public void BossWin()
    {
        _bossAnimator.SetTrigger("isBossWin");
    }

}
