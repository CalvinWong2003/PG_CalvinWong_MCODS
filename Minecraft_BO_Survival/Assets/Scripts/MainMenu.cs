using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LevelSelectionName = "LevelSelection";
    public void StartGame()
    {
        SceneManager.LoadScene(LevelSelectionName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
