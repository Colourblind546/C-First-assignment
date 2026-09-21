using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TeslaPulseItem : Item
{

    List<GameObject> teslaBullet = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }

    // Torment pulse RAAAAAHHHHH. Damages a number of enemies within range, scaling max targets and range with number of stacks
    public override void ActivateEffect() 
    {
        base.ActivateEffect();
        List<GameObject> enemies = new List<GameObject>();
        foreach (Collider2D target in Physics2D.OverlapCircleAll(transform.position, totalRange, targetLayer))
        {
            enemies.Add(target.gameObject);
        }

        for (int i = 0; i < enemies.Count; i++)
        {
            
        }
        
    }
}
