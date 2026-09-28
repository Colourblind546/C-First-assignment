using NUnit.Framework;
using UnityEngine;

public class TeslaPulseBulletEffect : Bullet
{

    [SerializeField] float lifeTime;
    float fadeAmount;
    [SerializeField] Material material;
    LineRenderer line;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    internal override void BulletEffect(GameObject target)
    {
        Debug.Log("Does zis work?");
        AppearTeslaPulseEffect(TeslaPulseItem.Instance.transform.position, target.transform.position);
        DoDamage(target);
        
    }

    public void AppearTeslaPulseEffect(Vector2 startPosition, Vector2 endPosition) // SET UP OVERRIDES FOR BULLETEFFECT
    {
        line.SetPosition(0, startPosition);
        line.SetPosition(1, endPosition);
        line.enabled = true;
        Invoke(nameof(DisappearTeslaPulseEffect), 0.1f);
    }
    internal void DisappearTeslaPulseEffect()
    {
        line.enabled = false;
    }
}
