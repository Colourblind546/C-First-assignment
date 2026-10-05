using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TeslaPulseItem : Item
{
    //public static TeslaPulseItem Instance;

    new public static Item Instance;

    List<TeslaPulseBulletEffect> teslaBulletPool = new List<TeslaPulseBulletEffect>();

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
        PoolBullets(stacks);
        

    }

    // Torment pulse RAAAAAHHHHH. Damages a number of enemies within range, scaling max targets and range with number of stacks
    public override void ActivateEffect() 
    {
        List<GameObject> enemies = new List<GameObject>();
        foreach (Collider2D target in Physics2D.OverlapCircleAll(transform.position, totalRange, targetLayer))
        {
            enemies.Add(target.gameObject);
        }

        if (enemies.Count > stacks)
        {
            enemies.RemoveRange(stacks, enemies.Count - stacks);
        }

        for (int i = 0; i < enemies.Count; i++)
        {
            Debug.Log(enemies);
            GameObject currentBullet = ActivatePooledBullets();
            Bullet currentBulletScript = currentBullet.GetComponent<Bullet>();
            Debug.Log($"Pulse n:{i}");
            currentBulletScript.BulletEffect(enemies[i]);
        }
        
    }
}
