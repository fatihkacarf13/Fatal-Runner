using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : MonoBehaviour
{
    private bool bossBackJump = true;

    void Update()
    {
        if (Boss.Instance.bossHealt<=0)
        {
            StartCoroutine(WaitForDance(2f));
        }
    }

    private IEnumerator WaitForDance(float waitTime)
    {
        if (bossBackJump)
        {
            transform.Translate(Vector3.back * Time.deltaTime * NewPlayer.Instance.playerPower / 4);
        }
         yield return new WaitForSeconds(waitTime);
        bossBackJump = false;
        yield return new WaitForSeconds(3f);
        NewPlayer.Instance.NextLevel();
    }
}
