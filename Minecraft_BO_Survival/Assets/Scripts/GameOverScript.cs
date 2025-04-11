using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverPanel;
    Button RetryButton;
    Button LevelSelectButton;
    Button QuitButton;

    void Start()
    {
        gameOverPanel.SetActive(false);
        Button[] buttons = GetComponentsInChildren<Button>();
        foreach (Button b in buttons)
        {
            if (b.name == "RetryButton")
            {
                RetryButton = b;
            }
            if (b.name == "LevelSelect")
            {
                LevelSelectButton = b;
            }
            if (b.name == "QuitButton")
            {
                QuitButton = b;
            }
        }
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LevelSelect()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelection");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("You have quit the game, Come back next time");
    }
}
