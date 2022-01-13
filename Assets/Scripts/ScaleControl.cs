using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleControl : MonoBehaviour
{
    public float increment = 0.1f;

    public void ScaleD()
    {
        transform.localScale -= Vector3.one * increment;
        transform.position = new Vector3(transform.position.x, transform.localScale.y, transform.position.z);
    }

}
