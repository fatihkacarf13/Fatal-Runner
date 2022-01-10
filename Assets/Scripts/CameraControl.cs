using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform follow;
    
    void LateUpdate()
    {
        if (follow)
        {
            transform.position = follow.transform.position + new Vector3(0, 3f+ follow.transform.localScale.y, -5);
        }
    }
}
