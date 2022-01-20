using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Drag : MonoBehaviour
{
    public static Drag Instance;
    public float clampX;
    public float speed;
    private float _lastMousePosition;
    private float _currentPositionX = 0;

    public void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
    }

    void FixedUpdate()
    {
        DragX();
    }

  private void DragX()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _lastMousePosition = Input.mousePosition.x;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (_lastMousePosition==0)
            {
                _lastMousePosition = Input.mousePosition.x;
            }
            float diffX = Input.mousePosition.x - _lastMousePosition;
            float moveX = diffX * speed *Time.deltaTime;
            _currentPositionX += moveX;
            _currentPositionX = Mathf.Clamp(_currentPositionX, -clampX, clampX);
            transform.position = new Vector3(_currentPositionX, transform.position.y, transform.position.z);
        }
    }
}
