using UnityEngine;

public class TRayItem : Item
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
        time = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (stacks > 0)
        {
            PoolBullets(1);
        }
    }

    override internal void CheckTimerAndEffect()
    {
        if (time > totalCooldown)
        {
            if (Physics2D.OverlapCircle(transform.position, totalRange, targetLayer))
            {
                ActivateEffect();
                time = 0;
            }
        }
    }

    public GameObject debugBox;
    public override void ActivateEffect()
    {
        Debug.Log("IS THIS WORKING?!!");
        time = 0;
        Collider2D targetCollider = Physics2D.OverlapCircle(transform.position, totalRange, targetLayer);
        GameObject target = null;
        if (targetCollider != null)
        {
            target = targetCollider.gameObject;
        }
        Vector3 overlapCentreOffset = (target.transform.position - transform.position).normalized * totalRange;
        float overlapRotation = Mathf.Rad2Deg * Mathf.Atan(overlapCentreOffset.y / overlapCentreOffset.x);
        Debug.Log("Rotation: " + overlapRotation);
        Debug.Log("Position: " + overlapCentreOffset);

        Collider2D[] enemiesHit = Physics2D.OverlapBoxAll(overlapCentreOffset + transform.position, new Vector2(totalRange * 2, 5f), overlapRotation, targetLayer);
        foreach (Collider2D enemyCollider in enemiesHit)
        {
            GameObject enemyObj = enemyCollider.gameObject;
            Enemy enemy = enemyObj.GetComponent<Enemy>();
            enemy.TakeDamage(Mathf.CeilToInt(totalDamage));
        }

        GameObject currentBullet = ActivatePooledBullets();
        LuminousRayBullet currentBulletScript = currentBullet.GetComponent<LuminousRayBullet>();
        currentBulletScript.AppearLightRayEffect(transform.position, overlapCentreOffset * 2 + transform.position);
        currentBulletScript.AppearLightRayEffect(transform.position, overlapCentreOffset * 2 + transform.position);

    }
}
