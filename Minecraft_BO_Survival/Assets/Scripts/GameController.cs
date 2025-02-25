using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject Enemy;
    public float offset = 2.0f;
    public Transform[] spawnPoints;
    public float spawnRate = 3f;

    public static GameController Instance;
    public int score;
    public Text scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnRate);
    }

    void SpawnEnemy()
    {
        int index = Random.Range(0, spawnPoints.Length);
        Instantiate(Enemy, spawnPoints[index].position, Quaternion.identity);
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
