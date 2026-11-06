using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GayRayItem : Item
{

    [SerializeField] int ticksPerSecond;
    float secondsBetweenTicks = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stacks != 0)
        {
            PoolBullets(1);
        }
    }

    override internal void CheckTimerAndEffect()
    {
        if (time > totalCooldown)
        {
            if (Physics2D.OverlapCircle(transform.position, 10f, targetLayer))
            {
                ActivateEffect();
                time = 0;
            }
        }
    }

    public override void ActivateEffect()
    {
        secondsBetweenTicks = 1 / (float)ticksPerSecond;

        StartCoroutine(nameof(LaserSweep));

        
    }

    IEnumerator LaserSweep()
    {

        GameObject laser = ActivatePooledBullets();
        laser.GetComponent<SelfDestruct>().SelfDisableSequence(totalDuration);

        Collider2D targetCollider = Physics2D.OverlapCircle(transform.position, 10f, targetLayer);
        GameObject target = null;
        if (targetCollider != null)
        {
            target = targetCollider.gameObject;
        }
        Vector3 overlapCentreOffset = (target.transform.position - transform.position).normalized * totalRange / 2;
        float overlapRotation = Mathf.Rad2Deg * Mathf.Atan(overlapCentreOffset.y / overlapCentreOffset.x);
        if (overlapCentreOffset.x < 0)
        {
            overlapRotation += 180;
        }

        float laserDurationTimer = 0;
        float laserTickCooldownTimer = 0;

        while (laserDurationTimer < totalDuration)
        {
            laserDurationTimer += Time.deltaTime;
            laserTickCooldownTimer += Time.deltaTime;

            laser.transform.position = overlapCentreOffset + transform.position;
            laser.transform.rotation = Quaternion.AngleAxis(overlapRotation, Vector3.forward);

            Collider2D[] enemiesHit = Physics2D.OverlapBoxAll(overlapCentreOffset + transform.position, new Vector2(totalRange, 2f), overlapRotation, targetLayer);

            Debug.Log("Laser Rotation: " + overlapRotation);
            if (laserTickCooldownTimer > secondsBetweenTicks)
            {
                laserTickCooldownTimer = 0;

                foreach (Collider2D enemyCollider in enemiesHit)
                {
                    GameObject enemyObj = enemyCollider.gameObject;
                    Enemy enemy = enemyObj.GetComponent<Enemy>();
                    enemy.TakeDamage(Mathf.CeilToInt(totalDamage));
                }
            }

            overlapRotation -= 15 * Time.deltaTime;
            overlapCentreOffset = (Quaternion.AngleAxis(overlapRotation, Vector3.forward) * Vector3.right).normalized * totalRange / 2;

            yield return null;
        }

        
    }
}
