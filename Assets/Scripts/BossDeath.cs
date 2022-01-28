using System.Collections;
using System.Collections.Generic;
using TMPro;
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


    //public void JumpPlatformPrefab(int value)
    //{
    //    //Vector3 bosstransform = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);

    //    Instantiate(jumpPlatform, platformCreator.transform.position, Quaternion.identity);
    //    if (crateAnother)
    //    {
    //        Vector3 raned= new Vector3(platformCreator.transform.position.x, platformCreator.transform.position.y,platformCreator.transform.position.z + range);
    //        Instantiate(jumpPlatform, raned, Quaternion.identity);
    //        range += 3;
    //        crateAnother = false;
    //    }

    //}




}
