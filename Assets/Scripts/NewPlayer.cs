using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NewPlayer : BaseColorable
{
    [SerializeField] private ColorType startColor;
    public Vector3 increment = Vector3.one * 0.1f;
    static int _scoreCount = 0;
    public Text scoreText;
    public int bossHealt;
    static int nextLevel = 0;

    private void Awake()
    {
        SetColor(startColor);
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
            if (col.gameObject.CompareTag("Wall"))
            {
            if (transform.localScale.y * 2 > col.transform.localScale.y)
            {
                _scoreCount += 10;
                scoreText.text = "Score:" + _scoreCount;
                Destroy(col.gameObject);

            }
            else
            {
                _scoreCount = 0;
                Destroy(gameObject);
                nextLevel = 0;
                SceneManager.LoadScene(nextLevel);
            }

            }

            if (col.CompareTag("Boss"))
            {
            if (transform.localScale.y>=col.transform.localScale.y)
            {
                _scoreCount += 20;
                Destroy(col.gameObject);
                nextLevel++;
                SceneManager.LoadScene(nextLevel);
            }
            else
            {
                _scoreCount = 0;
                Destroy(gameObject);
                nextLevel = 0;
                SceneManager.LoadScene(nextLevel);
            }
            }

        if (col.CompareTag("Enemy"))
        {

            _scoreCount = 0;
            nextLevel = 0;
            Destroy(col.gameObject);
            SceneManager.LoadScene(nextLevel);
            
        }
    }
}
