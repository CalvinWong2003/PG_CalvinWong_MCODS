using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Instatiating Enemy from specific spawn points
    public GameObject Zombie;
    public Transform[] spawnPoints;
    public float spawnRate = 3f;

    public GameObject MedKit;
    public GameObject ArmorPlate;
    [SerializeField] public Transform[] spawnPrefabPoints;
    private Dictionary<int, Coroutine> respawnCoroutines = new Dictionary<int, Coroutine>();

    public static GameController Instance;
    public int score;
    public Text scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnRate);

        InitializeSpawns();
    }
    
    private void InitializeSpawns()
    {
        for(int i = 0; i < spawnPrefabPoints.Length; i++)
        {
            SpawnPickup(i);
        }
    }

    void SpawnEnemy()
    {
        int index = Random.Range(0, spawnPoints.Length);
        Instantiate(Zombie, spawnPoints[index].position, Quaternion.identity);
    }

    void SpawnPickup(int index)
    {
        if (spawnPrefabPoints[index].childCount == 0)
        {
            bool isMedKit = Random.value > 0.5f;
            GameObject pickupSpawn = isMedKit ? MedKit : ArmorPlate;
            GameObject spawnedPickup = Instantiate(pickupSpawn, spawnPrefabPoints[index].position, Quaternion.identity);
            spawnedPickup.transform.parent = spawnPrefabPoints[index];

        }
    }

    public void StartRespawnTimer(int index)
    {
        if(!respawnCoroutines.ContainsKey(index))
        {
            respawnCoroutines[index] = StartCoroutine(RespawnPickup(index));
        }
    }
    private IEnumerator RespawnPickup(int index)
    {
        yield return new WaitForSeconds(60f);
        SpawnPickup(index);
        respawnCoroutines.Remove(index);
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
