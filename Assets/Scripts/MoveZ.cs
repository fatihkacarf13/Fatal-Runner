using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZ : MonoBehaviour
{
    public bool isMove;
    public float speedZ;
    public static MoveZ Instance;
    
    public void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
    }

    void Update()
    {
        if (isMove)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speedZ);
        }
    }
}
