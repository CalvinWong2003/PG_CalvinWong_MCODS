using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public void Retry()
    {
        string levelToReload = GameOverManager.lastSceneBeforeGameOver;
        
        if(!string.IsNullOrEmpty(levelToReload) && isValidLevel(levelToReload))
        {
            SceneManager.LoadScene(levelToReload);
        }
        else
        {
            Debug.Log("No valid level stored. Loading default level...");
            SceneManager.LoadScene("Level1");
        }
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelection");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("You have quit the game, Come back next time");
    }

    private bool isValidLevel(string levelname)
    {
        return levelname == "Level1" || levelname == "Level2" || 
                levelname == "Level3" || levelname == "Level4";
    }
}
