using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    string levelSelectionName = "LevelSelection";
    public void Retry()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene(levelSelectionName);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("You have quit the game, Come back next time");
    }
}
