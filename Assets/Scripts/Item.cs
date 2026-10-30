using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Item Instance;

    [Header("Card Stuff")]
    [SerializeField] public int cardType;

    [SerializeField] internal string itemName;
    [SerializeField] internal string description;
    [SerializeField] internal string scalingInformation;
    [SerializeField] internal Sprite icon;

    [Header("Base stats")]
    [SerializeField] internal float cooldown;
    [SerializeField] internal float duration;
    [SerializeField] internal float range;
    [SerializeField] internal float damage;


    [Header("Stack scaling")]
    [SerializeField] internal float extraCooldown;
    [SerializeField] internal float extraDuration;
    [SerializeField]internal float extraRange;
    [SerializeField] internal float extraDamage;


    [Header("Stats with stacks")]
    [SerializeField] internal float totalCooldown;
    [SerializeField] internal float totalDuration;
    [SerializeField] internal float totalRange;
    [SerializeField] internal float totalDamage;


    [Header("Stat limiters")]
    [SerializeField] internal float minCooldown;
    [SerializeField] internal float maxDuration;
    [SerializeField] internal float maxRange;
    [SerializeField] internal float maxDamage;


    [Header("Timer stuff")]
    [SerializeField] internal float time;


    [Header("Targeting stuff")]
    [SerializeField] internal LayerMask targetLayer;

    [Header("Give me more stacks!!!")]
    public int stacks;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void Timer()
    {
        time += Time.deltaTime;
    }
    virtual internal void CheckTimerAndEffect()
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
    internal void SetTotalStats()
    {
        totalCooldown = cooldown - extraCooldown * (stacks - 1);
        totalDuration = duration + extraDuration * (stacks - 1);
        totalRange = range + extraRange * (stacks - 1);
        totalDamage = damage + extraDamage * (stacks - 1);

        if (totalCooldown <= minCooldown)
        {
            if (minCooldown != 0)
            {
                totalCooldown = minCooldown;
            }
        }
        if (totalDuration > maxDuration)
        {
            if (maxDuration != 0)
            {
                totalDuration = maxDuration;
            }
        }
        if (totalRange > maxRange)
        {
            if (maxRange != 0)
            {
                totalRange = maxRange;
            }
        }
        if (totalDamage > maxDamage)
        {
            if (maxDamage != 0)
            {
                totalDamage = maxDamage;
            }
        }
    }
    virtual public void ActivateEffect()
    {
        
    }

    [SerializeField] internal List<GameObject> bullet = new List<GameObject>();
    [SerializeField] internal GameObject bulletObj;
    internal void PoolBullets(int maxBulletCount)
    {
        while (bullet.Count < maxBulletCount)
        {
            GameObject currentBullet = Instantiate(bulletObj);
            currentBullet.SetActive(false);
            bullet.Add(currentBullet);
        }
        while (bullet.Count > maxBulletCount)
        {
            bullet.RemoveAt(0);
        }
    }
    internal int bulletToUse;
    internal GameObject ActivatePooledBullets()
    {
        GameObject activatedBullet = bullet[bulletToUse];
        activatedBullet.SetActive(true);
        bulletToUse++;
        if (bulletToUse == bullet.Count)
        {
            bulletToUse = 0;
        }
        return activatedBullet;
    }
    
}
