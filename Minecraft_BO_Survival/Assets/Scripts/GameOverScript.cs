using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void Retry()
    {
        
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelection");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
