using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] internal LayerMask targetLayer;
    [SerializeField] public int damage;
    [SerializeField] public float speed;
    [SerializeField] public Vector2 direction;
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
