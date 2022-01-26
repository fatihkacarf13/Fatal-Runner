using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NewPlayer : BaseColorable
{
    [SerializeField] private ColorType startColor;
    [SerializeField] private Text scoreText;
    public GameObject floatingTextPrefab;
    public AnimationStateController animStateController;
    public static NewPlayer Instance;
    public float increment = 0.05f;
    public int playerHealt = 100;
    public int playerPower = 0;
    static int _scoreCount = 0;
    static int level = 0;
    private bool _lastIsMove;

    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
        SetColor(startColor);
    }


    private void Update()
    {
        UpdateRunIdle();
        if (playerPower<0)
        {
            playerPower = 0;
        }
        if (playerPower>100)
        {
            playerPower = 100;
        }

    }

    private void UpdateRunIdle()
    {
        if (_lastIsMove != MoveZ.Instance.isMove)
        {
            _lastIsMove = MoveZ.Instance.isMove;
            if (MoveZ.Instance.isMove)
            {
                animStateController.Run();
            }
            else
            {
                animStateController.Idle();
            }
        }
    }

    public void ScaleUp()
    {
        
        transform.localScale += Vector3.one * increment;
        Score++;
        playerPower += 5;
        PowerPopUp("+5");
    }

    public void ScaleDown()
    {
        transform.localScale -= Vector3.one * increment;
        Score--;
        playerPower -= 5;
        PowerPopUp("-5");
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




    public void PowerPopUp(string text)
    {
        GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
        prefab.GetComponentInChildren<TextMesh>().text = text;
        Destroy(prefab,0.5f);
    }
}
