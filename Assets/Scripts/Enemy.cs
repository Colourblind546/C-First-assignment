using UnityEngine;

public class Enemy : MonoBehaviour
{
    internal GameObject playerObj;
    [SerializeField] internal int health;
    [SerializeField] internal GameObject experience;

    [SerializeField] internal float moveSpeed;
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

        Destroy(gameObject);
    }

    public virtual void DeathEffect()
    {

    }
    virtual internal void MoveTowards(Vector3 target)
    {

    }

    internal void FindPlayerInScene()
    {
        if (playerObj  == null)
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
        }
    }



}
