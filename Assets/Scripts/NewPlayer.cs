using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NewPlayer : BaseColorable
{
    [SerializeField] private ColorType startColor;
    public float increment =  0.05f;
    static int _scoreCount = 0;
    [SerializeField] private Text scoreText;
    static int level = 0;

    private void Awake()
    {
        SetColor(startColor);
    }

    public void ScaleUp()
    {
        transform.localScale += Vector3.one*increment;
        //transform.position = new Vector3(transform.position.x, transform.localScale.y, transform.position.z);
        Score++;
    }

    public void ScaleDown()
    {
        transform.localScale -= Vector3.one * increment;
        //transform.position = new Vector3(transform.position.x, transform.localScale.y, transform.position.z);
        Score--;

    }

    public int Score
    {
        get
        {
            return _scoreCount;
        }
        set
        {
            if (value>0)
            {
                _scoreCount = value;
            }
            else
            {
                _scoreCount = 0;  
            }
            scoreText.text = "Score:" + _scoreCount;
        }
    }

    public void NextLevel()
    {
        level++;
        //level = level % SceneManager.sceneCount;
        SceneManager.LoadScene(level);
        if (level==3)
        {
            level--;
        }
    }
    public void RestartLevel()
    {
        _scoreCount = 0;
        SceneManager.LoadScene(level);
    }

}
