using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : PlayerFight
{
    static int level = 0;
    public void NextLevel()
    {
        level++;
        level = level % SceneManager.sceneCount;
        SceneManager.LoadScene(level);
    }
    public void RestartLevel()
    {

        SceneManager.LoadScene(level);
    }

    //private void Update()
    //{
    //    if (winner==1)
    //    {
    //        RestartLevel();
    //    }
    //    if (winner == 2)
    //    {
    //        NextLevel();
    //    }
    //}

}
