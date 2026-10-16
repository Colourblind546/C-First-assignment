using UnityEngine;

public class ExpManager : MonoBehaviour
{
    [Header("Experience Modifiers")]
    [SerializeField] public int currentExp {  get; private set; }
    [SerializeField] public int expToLevel;
    [SerializeField] float expIncreaseCoefficient;
    [SerializeField] public int unspentLevels = 0;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RandomiseAndAppearCards cardControllerObj = Camera.main.gameObject.GetComponent<RandomiseAndAppearCards>();
        cardControllerObj.SetAllCards();
    }

    // Update is called once per frame
    void Update()
    {
        GetNearbyExp();
    }

    [Header("Experience Collection Stuff")]
    [SerializeField] float expFindRadius;
    [SerializeField] float expPickupRadius;
    [SerializeField] float expPullSpeed;
    [SerializeField] LayerMask expLayer;
    void GetNearbyExp()
    {
        float modifiedPickupRadius = Mathf.Clamp(expFindRadius + 0.10f * GameManager.Instance.wave, 5, 20);
        if (GameManager.Instance.remainingEnemies.Count == 0)
        {
            modifiedPickupRadius = 10000;
        }
        Collider2D[] expColliders = Physics2D.OverlapCircleAll(transform.position, modifiedPickupRadius, expLayer);
        foreach (Collider2D collider in expColliders)
        {
            Experience exp = collider.gameObject.GetComponent<Experience>();
            if (Vector2.Distance(transform.position, collider.gameObject.transform.position) < expPickupRadius)
            {
                currentExp += exp.GetExp();
                Destroy(collider.gameObject);
                continue;
            }

            collider.gameObject.transform.position -= (collider.transform.position - transform.position).normalized * expPullSpeed * Time.deltaTime;

        }
        if (expToLevel <= currentExp)
        {
            LevelUp();
        }
    }

    [ContextMenu("Level Up")]
    void LevelUp()
    {
        PlayerHealth playerHealth = gameObject.GetComponent<PlayerHealth>();
        playerHealth.health = playerHealth.maxHealth;
        RandomiseAndAppearCards cardControllerObj = Camera.main.gameObject.GetComponent<RandomiseAndAppearCards>();
        if (unspentLevels == 0)
        {
            cardControllerObj.SetAllCards();
        }
        unspentLevels++;

        GameManager.Instance.waitForWave = false;

        // Prepares for next level up
        float expToLevelFloat = expToLevel;
        expToLevel = Mathf.RoundToInt(expToLevelFloat * expIncreaseCoefficient);
        currentExp = 0;
    }


}
