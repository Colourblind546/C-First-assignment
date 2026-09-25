using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] internal LayerMask targetLayer;
    [SerializeField] internal int damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal virtual void BulletEffect(GameObject target)
    {

    }

    internal void DoDamage(GameObject target)
    {
        target.GetComponent<Enemy>().TakeDamage(damage);
    }
}
