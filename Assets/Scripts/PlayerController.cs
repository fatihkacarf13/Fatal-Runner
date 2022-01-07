using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
   
    public float clampX;
    public float speed;
    private int _score = 0;
    public Text point;

    private Vector3 lastMousePosition;

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


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Point"))
        {
            _score++;
            point.text = "Score:" + _score;
            Destroy(col.gameObject);
        }
    }

   






}
