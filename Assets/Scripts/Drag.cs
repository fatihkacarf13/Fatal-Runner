using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public static Drag Instance;
    public float clampX;
    public float speed;
    private Vector3 lastMousePosition;
    

    public void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            lastMousePosition = Input.mousePosition;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 diff = Input.mousePosition - lastMousePosition;
            float moveX = diff.x * speed;
            moveX = Mathf.Clamp(moveX, -clampX, clampX);
            transform.position = new Vector3(moveX, transform.position.y, transform.position.z);
        }
    }

}
