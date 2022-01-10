using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NewPlayer : BaseColorable
{
    public float clampX;
    public float speed;
    [SerializeField] private ColorType startColor;
    private Vector3 lastMousePosition;
    public Vector3 increment = Vector3.one * 0.1f;
    int scoreCount = 0;
    public Text scoreText;

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
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        scoreCount++;
        scoreText.text = "Score : " + scoreCount;
    }

    public void ScaleDown()
    {
        transform.localScale -= increment;
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
        if (scoreCount==0)
        {
            scoreCount = 0;
            scoreText.text = "Score : " + scoreCount;
        }
        else
        {
            scoreCount--;
            scoreText.text = "Score : " + scoreCount;
        }
        
    }

     void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Boss"))
        {
            if (scoreCount>=10)
            {
                Destroy(col.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
