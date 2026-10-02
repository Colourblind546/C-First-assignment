using UnityEngine;

public class ExpManager : MonoBehaviour
{
    [Header("Experience Modifiers")]
    [SerializeField] int currentExp;
    [SerializeField] int expToLevel;
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
        Collider2D[] expColliders = Physics2D.OverlapCircleAll(transform.position, expFindRadius, expLayer);
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
        RandomiseAndAppearCards cardControllerObj = Camera.main.gameObject.GetComponent<RandomiseAndAppearCards>();
        if (unspentLevels == 0)
        {
            cardControllerObj.SetAllCards();
        }
        unspentLevels++;
        // Give player item options



        // Prepares for next level up
        float expToLevelFloat = expToLevel;
        expToLevel = Mathf.RoundToInt(expToLevelFloat * expIncreaseCoefficient/* * GameManager.levelDifficultyModifier*/);
        currentExp = 0;
    }


}
