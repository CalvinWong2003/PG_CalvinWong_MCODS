using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Instatiating Enemy from specific spawn points
    public GameObject Enemy;
    public Transform[] spawnPoints;
    public float spawnRate = 3f;

    //Instatiating MedKits from specific spawn points with timer
    public GameObject MedKit;
    public Transform[] MedKitSpawnPoints;
    float MedKitTimer = 0;

    //Instatiating Armor Plates from specific spawn points with timer
    public GameObject ArmorPlate;
    public Transform[] ArmorPlateSpawnPoints;
    float ArmorPlateTimer = 0;

    public static GameController Instance;
    public int score;
    public Text scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnRate);

        InvokeRepeating("SpawnMedKit", 1f, 60f);
        InvokeRepeating("SpawnArmorPlate", 1f, 60f);
    }

    void SpawnEnemy()
    {
        int index = Random.Range(0, spawnPoints.Length);
        Instantiate(Enemy, spawnPoints[index].position, Quaternion.identity);
    }

    void SpawnMedKit()
    {
        int index = Random.Range(0, MedKitSpawnPoints.Length);
        Instantiate(MedKit, MedKitSpawnPoints[index].position, Quaternion.identity);
        
        for(int i = 0; i < index; i++)
        {
            if (MedKit == null)
            {
                MedKitTimer += Time.deltaTime;
                if (MedKitTimer == 60)
                {
                    Instantiate(MedKit, MedKitSpawnPoints[index].position, Quaternion.identity);
                }
            }
        }
    }
    void SpawnArmorPlate()
    {
        int index = Random.Range(0, ArmorPlateSpawnPoints.Length);
        Instantiate(ArmorPlate, ArmorPlateSpawnPoints[index].position, Quaternion.identity);
        
        for (int i = 0; i < index; i++)
        {
            if (ArmorPlate == null)
            {
                ArmorPlateTimer += Time.deltaTime;
                if (ArmorPlateTimer == 60)
                {
                    Instantiate(ArmorPlate, ArmorPlateSpawnPoints[index].position, Quaternion.identity);
                }
            }
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
