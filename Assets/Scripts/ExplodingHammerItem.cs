using UnityEngine;

public class ExplodingHammerItem : Item
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
            PoolBullets(5);
        }
    }

    override internal void CheckTimerAndEffect()
    {
        if (time > totalCooldown)
        {
            if (Physics2D.OverlapCircle(transform.position, 12.5f, targetLayer))
            {
                ActivateEffect();
                time = 0;
            }
        }
    }

    public override void ActivateEffect()
    {
        GameObject target = Physics2D.OverlapCircle(transform.position, 12.5f, targetLayer).gameObject;

        if (target != null)
        {
            GameObject hammer = ActivatePooledBullets();
            hammer.GetComponent<SelfDestruct>().SelfDisableSequence(4f);

            hammer.transform.position = transform.position;
            Bullet hammerScript = hammer.GetComponent<Bullet>();
            hammerScript.damage = Mathf.CeilToInt(totalDamage);
            hammerScript.direction = (target.transform.position - transform.position).normalized;
        }
    }
}
