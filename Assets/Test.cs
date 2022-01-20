using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float speed;
    public float z;
    public bool _rotated = false;
    public float resetTimer;



    private void Start()
    {
        InvokeRepeating("RotateP", Time.deltaTime, resetTimer);
        InvokeRepeating("ResetRotate", resetTimer/2, resetTimer);
    }

    //private IEnumerator TrapDoorRotate(float waitTime)
    //{
    //    while (true)
    //    {
    //        for (int i = 0; i < 1; i++)
    //        {
                
    //            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0, 0, z), Time.deltaTime * speed);
    //            yield return new WaitForSeconds(waitTime);

    //        }
    //        yield return new WaitForSeconds(waitTime);
    //        transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0, 0, 0), Time.deltaTime * speed);
    //    }
      

    //}

    private void RotateP()
    {
        transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0, 0, z), Time.deltaTime * speed);
    }

    private void ResetRotate()
    {
        transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0, 0, z), Time.deltaTime * speed);
    }
}