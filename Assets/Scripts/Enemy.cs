using UnityEngine;

public class Enemy : MonoBehaviour
{
    internal GameObject playerObj;
    [SerializeField] internal int health;
    [SerializeField] internal GameObject experience;

    [SerializeField] internal float moveSpeed;

    [SerializeField] internal int damage;
    [SerializeField] internal float attackCooldown;
    [SerializeField] internal float attackTimer;
    [SerializeField] internal LayerMask playerLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindPlayerInScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
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
