using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform follow;
    
    void LateUpdate()
    {
        transform.position = follow.transform.position + new Vector3(15, 1, 0);
    }
}
