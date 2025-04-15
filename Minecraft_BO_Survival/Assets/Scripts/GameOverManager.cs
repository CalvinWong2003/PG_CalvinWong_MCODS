using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static string lastSceneBeforeGameOver;
    private bool isGameOver = false;
    public void PlayerDied()
    {
        if(isGameOver)
        {
            return;
        }
        isGameOver = true;
        lastSceneBeforeGameOver = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("GameOverUI");
    }
}
