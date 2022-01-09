using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
   
    public void startGame()
    {

        int Level = PlayerPrefs.GetInt("Level");

        if (Level==0)
        {
            SceneManager.LoadScene("Level1");
        }
        else
        {
            SceneManager.LoadScene(Level);

        }
    }

    
    public void exitGame()
    {
        Application.Quit();
    }
}
