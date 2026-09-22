using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] internal LayerMask targetLayer;
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

    internal virtual void BulletEffect(Vector2 startPosition,  Vector2 endPosition)
    {

    }

    internal virtual void BulletEffect(GameObject target, Vector2 startPosition, Vector2 endPosition)
    {

    }
}
