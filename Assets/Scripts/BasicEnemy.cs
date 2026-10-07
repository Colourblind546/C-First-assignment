using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class BasicEnemy : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindPlayerInScene();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowards(playerObj.transform.position);

        attackTimer += Time.deltaTime;
        if (attackTimer > attackCooldown)
        {
            Attack();
        }
    }

    Vector3 antiCollisionVector;
    private void OnTriggerStay(Collider other)
    {
        antiCollisionVector = other.gameObject.transform.position - transform.position;
        StopOverlap();
        Debug.Log("Collision");
    }

    void StopOverlap()
    {
        transform.position -= antiCollisionVector * Time.deltaTime;
    }

    internal override void MoveTowards(Vector3 target)
    {
        transform.position += (target - transform.position).normalized * moveSpeed * Time.deltaTime;
    }

    
}
