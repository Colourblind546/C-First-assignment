using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{




    public static GameManager Instance;

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

    void SpawnWave(int wave)
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
    
}
