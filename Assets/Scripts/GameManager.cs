using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    GameObject playerObj;
    PlayerHealth playerHealth;

    [SerializeField] GameObject[] basicEnemy;

    public float difficultyModifier;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(Instance);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObj = FindPlayer();
        playerHealth = playerObj.GetComponent<PlayerHealth>();
        StartCoroutine(WaveManager());
    }

    bool gameIsPaused = false;
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            if (!gameIsPaused)
            {
                Time.timeScale = 0;
            }
            if (gameIsPaused)
            {
                Time.timeScale = 1;
            }
            gameIsPaused = !gameIsPaused;
        }






    }
    
    public List<GameObject> remainingEnemies = new List<GameObject>();
    void SpawnEnemyWave(int wave)
    {
        remainingEnemies.Clear();
        waitForWave = true;
        float playerExpNeededForLevel = playerObj.GetComponent<ExpManager>().expToLevel;
        float expValue = Mathf.CeilToInt(5f * difficultyModifier);
        int enemySpawnAmount = Mathf.CeilToInt(playerExpNeededForLevel / expValue);
        for (int i = 0; i < enemySpawnAmount; i++)
        {
            int enemyChoice = UnityEngine.Random.Range(0, basicEnemy.Length);
            remainingEnemies.Add(Instantiate(basicEnemy[enemyChoice], SpawnPosition(), quaternion.identity).gameObject);
        }
        

    }

    Vector3 SpawnPosition()
    {
        Vector3 output = Vector3.zero;
        float angle = UnityEngine.Random.Range(0f, 360f);
        Vector3 direction = Quaternion.Euler(0f, 0f, angle) * Vector3.right;
        output = direction * UnityEngine.Random.Range(25f, 55f) + playerObj.transform.position;
        return output;
    }


    [SerializeField] public int wave = 0;
    public bool waitForWave;
    IEnumerator WaveManager()
    {
        waitForWave = false;

        Debug.Log("WHERE'RE THE FUCKIN' ENEMIES SHITHEAD!!!");

        while (playerHealth.health != 0)
        {



            SpawnEnemyWave(wave);

            while (waitForWave)
            {
                yield return null;
            }
            wave++;

        }






        yield return null; // To stop there from being a syntax error, remove later
    }

    /// <summary>
    /// Returns the player GameObject in the scene
    /// </summary>
    /// <returns></returns>
    GameObject FindPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }
    
}
