using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewPlayer : BaseColorable
{
    [SerializeField] private ColorType startColor;
    [SerializeField] private TextMeshProUGUI scoreText;

    public GameObject floatingTextPrefab;
    public AnimationStateController animStateController;
    public static NewPlayer Instance;
    public float increment = 0.05f;
    public int playerHealt = 100;
    public int playerPower = 0;
    static int _scoreCount = 0;
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
        PowerPopUp(5);
    }

    public void ScaleDown()
    {
        transform.localScale -= Vector3.one * increment;
        Score--;
        playerPower -= 5;
        PowerPopUp(-5);
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
            scoreText.text = "Score: " + _scoreCount;
        }
    }

    [Button]
    public void NextLevel()
    {
        var level = SceneManager.GetActiveScene().buildIndex;
        level++;
        level = level % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(level);
    }
    public void RestartLevel()
    {
        _scoreCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }




    public void PowerPopUp(int value)
    {
        var tmp = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity).GetComponentInChildren<TextMeshPro>();
        tmp.text = value.ToString();
        //tmp.color = value > 0 ? Color.white : Color.red;
        if (value>=0)
        {
            tmp.text = "+" + value.ToString();
            tmp.color = Color.white ;
        }
        else
        {
            tmp.text = value.ToString();
            tmp.color = Color.red;
        }
        Destroy(tmp.gameObject,0.5f);
    }
}
