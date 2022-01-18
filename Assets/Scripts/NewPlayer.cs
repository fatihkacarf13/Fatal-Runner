using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NewPlayer : BaseColorable
{
    [SerializeField] private ColorType startColor;
    [SerializeField] private Text scoreText;
    [SerializeField] private AnimationStateController _animStateController;
    [SerializeField] private MoveZ _moveZ;
    public int playerHealt = 20;
    public float increment = 0.05f;
    static int _scoreCount = 0;
    static int level = 0;
    private bool _lastIsMove;

    private void Awake()
    {
        SetColor(startColor);
    }


    private void Update()
    {
        UpdateRunIdle();

    }

    private void UpdateRunIdle()
    {
        if (_lastIsMove != _moveZ.isMove)
        {
            _lastIsMove = _moveZ.isMove;
            if (_moveZ.isMove)
            {
                _animStateController.Run();
            }
            else
            {
                _animStateController.Idle();
            }
        }
    }

    public void ScaleUp()
    {
        
        transform.localScale += Vector3.one * increment;
        Score++;
        playerHealt++;

    }

    public void ScaleDown()
    {
        
        transform.localScale -= Vector3.one * increment;
        Score--;
        playerHealt--;


    }

    public int Score
    {
        get
        {
            return _scoreCount;
        }
        set
        {
            if (value > 0)
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
        if (level == 3)
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
