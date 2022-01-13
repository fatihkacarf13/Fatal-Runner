using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float speed;
    public float z ;


    public void Update()
    {
        Vector3 to = new Vector3(0, 0, z);

        transform.eulerAngles= Vector3.Lerp(transform.rotation.eulerAngles, to, speed);


    }

}
