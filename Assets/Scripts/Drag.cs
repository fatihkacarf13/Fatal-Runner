using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Drag : MonoBehaviour
{
    public static Drag Instance;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float clampX = 60;

    private float _currentPositionX = 0;
    private float _lastPositionX;


    public void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
    }

    void FixedUpdate()
    {
        Swerve();
    }

    public void Swerve()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastPositionX = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0))
        {
            if (_lastPositionX == 0)
            {
                _lastPositionX = Input.mousePosition.x;
            }

            float currentX = Input.mousePosition.x;
            float deltaX = currentX - _lastPositionX;
            float targetX = deltaX * swerveSpeed * Time.deltaTime;
            _currentPositionX += targetX;
            _currentPositionX = Mathf.Clamp(_currentPositionX, -clampX, clampX);
            transform.position = new Vector3(_currentPositionX, transform.position.y, transform.position.z);
            _lastPositionX = Input.mousePosition.x;
            
        }
    }
}
