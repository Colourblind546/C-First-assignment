using Unity.VisualScripting;
using UnityEngine;

public class LuminousRayItem : Item
{

    new public static Item Instance;

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
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stacks > 0)
        {
            PoolBullets(1);
        }
    }

    public override void ActivateEffect()
    {
        Debug.Log("IS THIS WORKING?!!");
        time = 0;
        GameObject target = Physics2D.OverlapCircle(transform.position, totalRange, targetLayer).gameObject;
        Vector3 overlapCentre = (target.transform.position - transform.position).normalized * totalRange;
        float overlapRotation = Mathf.Rad2Deg * Mathf.Atan(overlapCentre.y / overlapCentre.x);

        Collider2D[] enemiesHit = Physics2D.OverlapBoxAll(overlapCentre, new Vector2(totalRange * 2, 0.5f), overlapRotation, targetLayer);
        foreach (Collider2D enemyCollider in enemiesHit)
        {
            GameObject enemyObj = enemyCollider.gameObject;
            Enemy enemy = enemyObj.GetComponent<Enemy>();
            enemy.TakeDamage(Mathf.CeilToInt(totalDamage));
        }

        GameObject currentBullet = ActivatePooledBullets();
        LuminousRayBullet currentBulletScript = currentBullet.GetComponent<LuminousRayBullet>();
        currentBulletScript.AppearLightRayEffect(transform.position, overlapCentre * 2);

    }
}
