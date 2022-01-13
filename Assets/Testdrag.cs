using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Testdrag : MonoBehaviour
{
    private float mZCoord;
    private Vector3 mOffset;
    public float clampX;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            float moveX = mOffset.x + GetMouseAsWorldPoint().x;
            moveX = Mathf.Clamp(moveX, -clampX, clampX);
            transform.position = new Vector3(moveX, transform.position.y, transform.position.z);
        }
    }

    Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
