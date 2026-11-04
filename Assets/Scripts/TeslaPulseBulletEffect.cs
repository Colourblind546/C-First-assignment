using NUnit.Framework;
using UnityEngine;

public class TeslaPulseBulletEffect : Bullet
{
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
        AppearTeslaPulseEffect(TeslaPulseItem.Instance.transform.position, target.transform.position);
        damage = Mathf.CeilToInt(TeslaPulseItem.Instance.totalDamage);
        DoDamage(target);
    }

    public void AppearTeslaPulseEffect(Vector2 startPosition, Vector2 endPosition) // SET UP OVERRIDES FOR BULLETEFFECT
    {
        line.SetPosition(0, startPosition);
        line.SetPosition(1, endPosition);
        line.enabled = true;
        float visualDuration = TeslaPulseItem.Instance.totalCooldown * 0.15f;
        if (visualDuration < 0.1)
        {
            visualDuration = 0.1f;
        }
        CancelInvoke(nameof(DisappearTeslaPulseEffect));
        Invoke(nameof(DisappearTeslaPulseEffect), visualDuration);
    }
    void DisappearTeslaPulseEffect()
    {
        line.enabled = false;
    }
}
