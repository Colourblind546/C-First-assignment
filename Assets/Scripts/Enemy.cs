using UnityEngine;
using UnityEngine.U2D;

public class Enemy : MonoBehaviour
{
    internal GameObject playerObj;
    [SerializeField] internal int health;
    [SerializeField] internal float healthScalingAfterWaveFive;
    [SerializeField] internal GameObject experience;

    [SerializeField] internal float moveSpeed;

    [SerializeField] internal int damage;
    [SerializeField] internal float attackCooldown;
    [SerializeField] internal float attackTimer;
    [SerializeField] internal LayerMask playerLayer;

    [SerializeField] internal SpriteRenderer sprite;
    [SerializeField] internal Color normalColor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindPlayerInScene();
        int currentWave = GameManager.Instance.wave + 1;
        if (GameManager.Instance.wave > 15)
        {
            health = health + Mathf.CeilToInt(healthScalingAfterWaveFive * (float)currentWave);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        FlashRed();

        if (health <= 0)
        {
            Die();
        }
    }

    internal void SetModifiedValues()
    {
        int currentWave = GameManager.Instance.wave + 1;
        if (GameManager.Instance.wave > 5)
        {
            health = health + Mathf.CeilToInt(healthScalingAfterWaveFive * (float)currentWave);
        }
        float randomUpOrDown = Random.Range(-0.1f, 0.1f);

        moveSpeed *= 1.0f + randomUpOrDown;
    }

    [ContextMenu("Kill")]
    public virtual void Die()
    {
        Instantiate(experience, transform.position, Quaternion.identity);
        GameManager.Instance.GetComponent<GameManager>().remainingEnemies.Remove(gameObject);
        Destroy(gameObject);
    }

    public virtual void DeathEffect()
    {

    }
    virtual internal void MoveTowards(Vector3 target)
    {

    }

    void FlashRed()
    {
        sprite.color = Color.red;
        CancelInvoke(nameof(ColorReset));
        Invoke(nameof(ColorReset), 0.1f);
    }
    void ColorReset()
    {
        sprite.color = normalColor;
    }

    internal virtual void Attack()
    {
        Collider2D playerCollider = Physics2D.OverlapBox(transform.position, Vector2.one, 0, playerLayer);
        if (playerCollider != null)
        {
            GameObject playerObj = playerCollider.gameObject;
            PlayerHealth playerHealth = playerObj.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
            attackTimer = 0;
        }
    }

    internal void FindPlayerInScene()
    {
        if (playerObj  == null)
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
        }
    }



}
