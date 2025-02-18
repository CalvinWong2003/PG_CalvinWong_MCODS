using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectUI : MonoBehaviour
{
    // Flag to determine which menu to show
    private bool showMainMenu = true;

    void OnGUI()
    {
        // If we're showing the main menu...
        if (showMainMenu)
        {
            // Center the main menu area on screen
            GUILayout.BeginArea(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100));
            
            // Display the title
            GUILayout.Label("Zombie Apocalypse", GUILayout.ExpandWidth(true));
            
            // "Play" button: on click, switch to the level selection layout
            if (GUILayout.Button("Play"))
            {
                showMainMenu = false;
            }
            
            GUILayout.EndArea();
        }
        // Otherwise, show the level selection screen
        else
        {
            // Center the level selection area on screen
            GUILayout.BeginArea(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 300, 300));
            
            GUILayout.Label("Select Level");

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
            
            GUILayout.EndArea();
        }
    }
}
