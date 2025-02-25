using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectUI : MonoBehaviour
{
    public void SelectLevel()
    {
        // Each button loads a different scene
        if (GUILayout.Button("Level 1"))
        {
            SceneManager.LoadScene("Level1");
        }
        if (GUILayout.Button("Level 2"))
        {
            SceneManager.LoadScene("Level2");
        }
        if (GUILayout.Button("Level 3"))
        {
            SceneManager.LoadScene("Level3");
        }
        if (GUILayout.Button("Level 4"))
        {
            SceneManager.LoadScene("Level4");
        }
        if (GUILayout.Button("Level 5"))
        {
            SceneManager.LoadScene("Level5");
        }
        if (GUILayout.Button("Level 6"))
        {
            SceneManager.LoadScene("Level6");
        }
    }
}
