using UnityEngine;

public class Item : MonoBehaviour
{
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
                ActivateEffect(stacks);
            }
        }
    }
    virtual public void ActivateEffect(int stacks)
    {
        totalCooldown = cooldown -= extraCooldown * stacks;
        totalDuration = duration += extraDuration * stacks;
        totalRange = range += extraRange * stacks;
        totalDamage = damage += extraDamage * stacks;

        if (totalCooldown <= 0)
        {
            totalCooldown = 0.01f;
        }
    }
}
