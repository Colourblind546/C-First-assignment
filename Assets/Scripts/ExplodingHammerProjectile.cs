using Unity.VisualScripting;
using UnityEngine;

public class ExplodingHammerProjectile : Bullet
{
    Item hammerItem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hammerItem = ExplodingHammerItem.Instance;
    }
    [SerializeField] GameObject explosionPrefab;
    // Update is called once per frame
    void Update()
    {
        if (direction.x >= 0)
        {
            transform.Rotate(Vector3.back, 1080f * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.back, -1080f * Time.deltaTime);
        }
            transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;

        if (Physics2D.OverlapCircle(transform.position, 1, targetLayer))
        {
            BulletEffect(null);
            GameObject explosionObject = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            explosionObject.GetComponent<SelfDestruct>().SelfDestructSequence(0.5f);

            Item hammerItem = ExplodingHammerItem.Instance;
            explosionObject.transform.localScale = new Vector2(hammerItem.totalRange * 2, hammerItem.totalRange * 2);

            gameObject.SetActive(false);
        }
    }

    internal override void BulletEffect(GameObject target)
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, hammerItem.totalRange, targetLayer);

        foreach (Collider2D enemyCollider in targets)
        {
            GameObject enemyObj = enemyCollider.gameObject;
            Enemy enemy = enemyObj.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(Mathf.CeilToInt(hammerItem.totalDamage));
            }
        }
    }


}
