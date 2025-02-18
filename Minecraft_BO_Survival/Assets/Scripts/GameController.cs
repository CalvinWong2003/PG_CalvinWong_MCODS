using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Transform Enemy;
    public float offset = 2.0f;

    public static GameController Instance;
    public int score;
    public Text scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            Instantiate(Enemy, new Vector3((i * offset) - 10, 0, 8), Quaternion.identity);
        }
        for(int i = 0; i < 10; i++)
        {
            Instantiate(Enemy, new Vector3((i * offset) - 12, 0, 12), Quaternion.identity);
        }
        for(int i = 0; i < 10; i++)
        {
            Instantiate(Enemy, new Vector3((i * offset) - 14, 0, 16), Quaternion.identity);
        }
    }

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }
    void UpdateScoreUI()
    {
        if(scoreDisplay != null)
        {
            scoreDisplay.text = "Score = " + score.ToString();
        }
    }
}
