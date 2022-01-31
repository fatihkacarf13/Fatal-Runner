using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform follow;
    public Transform target;
    public Transform fight;
    public Transform boss;


    public float speed = 1.0f;

    void LateUpdate()
    {
        if (FightLineControl.Instance.bossFight==false)
        {
            if (follow)
            {
                transform.position = follow.transform.position + new Vector3(0, 4f + follow.transform.localScale.y, -5 - follow.transform.localScale.y);
            }
        }
        else 
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            transform.LookAt(fight);
            if (Boss.Instance.bossHealt <= 0)
            {
                
                transform.position = boss.transform.position + new Vector3(6, 5, -10);
                transform.LookAt(boss);
            }
        }

    }


}
