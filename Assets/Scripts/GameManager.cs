using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    GameObject playerObj;
    PlayerHealthStuff playerHealth;

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
        playerHealth = playerObj.GetComponent<PlayerHealthStuff>();
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

    void SpawnEnemyWave(int wave)
    {
        
    }

    Vector3 SpawnPosition()
    {
        Vector3 output = Vector3.zero;
        float angle = UnityEngine.Random.Range(0f, 360f);
        Vector3 direction = Quaternion.Euler(0f, 0f, angle) * Vector3.right;
        output = direction * 25;
        return output;
    }

    IEnumerator WaveManager()
    {
        int wave = 0;

        while (playerHealth.health != null)
        {

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
