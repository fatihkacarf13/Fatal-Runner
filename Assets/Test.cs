using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{



    public void Update()
    {

        if (transform.rotation.z == 0)
        {
            transform.Rotate(0, 0, 45 * Time.deltaTime);
        }
        if (transform.rotation.z == 90)
        {
            transform.Rotate(0, 0,- 45 * Time.deltaTime);
        }
    }


}
