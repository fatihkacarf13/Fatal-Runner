using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NewPlayer : BaseColorable
{

    public float clampX;
    public float speed;
    [SerializeField] private ColorType startColor;
    private Vector3 lastMousePosition;
    public Vector3 increment = Vector3.one * 0.1f;


    private void Awake()
    {
        SetColor(startColor);
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



    public void ScaleUp()
    {
        transform.localScale += increment;
    }

    public void ScaleDown()
    {
        transform.localScale -= increment;
    }



}
