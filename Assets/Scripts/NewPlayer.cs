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
    private int _scoreCount = 0;
    public Text scoreText;
    public int bossHealt;

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
        _scoreCount++;
        scoreText.text = "Score : " + _scoreCount;
    }

    public void ScaleDown()
    {
        transform.localScale -= increment;
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
        if (_scoreCount==0)
        {
            _scoreCount = 0;
            scoreText.text = "Score : " + _scoreCount;
        }
        else
        {
            _scoreCount--;
            scoreText.text = "Score : " + _scoreCount;
        }
        
    }

     void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Boss"))
        {
            if (_scoreCount>=bossHealt)
            {

                Destroy(col.gameObject);
                SceneManager.LoadScene("Level5");
            }
            else
            {
                _scoreCount = 0;
                Destroy(gameObject);
                SceneManager.LoadScene("Level4");
            }
        }
    }
}
