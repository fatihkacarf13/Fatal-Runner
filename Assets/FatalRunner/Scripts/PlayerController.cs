using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{


    public float clampX;
    public float speed;
    static int _score = 0;
    public Text point;
    private Vector3 lastMousePosition;
    static int nextLevel = 1;



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


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Point"))
        {
            _score++;
            point.text = "Score:" + _score;
            Destroy(col.gameObject);
        }

        if (col.CompareTag("Finish"))
        {

            nextLevel++;

            SceneManager.LoadScene(nextLevel);
            
        }

        if (col.CompareTag("Enemy"))
        {
            _score = 0;
            nextLevel = 1;
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
    }


}
