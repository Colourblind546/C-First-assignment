using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int health;
    [SerializeField] GameObject experience;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

        Destroy(gameObject);
    }

    public virtual void DeathEffect()
    {

    }


}
