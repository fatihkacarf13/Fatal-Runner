using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbedStick : MonoBehaviour
{
    private float speed = 1;
    private float t;
    public Vector3 borderA;
    public Vector3 borderB;

    private void Update()
    {
        t += Time.deltaTime * speed;
        
        transform.position = Vector3.Lerp(borderA, borderB, t);

        if (t >= 1)
        {
            var b = borderB;
            var a = borderA;
            borderA = b;
            borderB = a;
            t = 0;

        }
    }


}
