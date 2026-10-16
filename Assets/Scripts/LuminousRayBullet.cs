using UnityEngine;

public class LuminousRayBullet : Bullet
{

    LineRenderer line;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AppearLightRayEffect(Vector2 startPosition, Vector2 endPosition) // SET UP OVERRIDES FOR BULLETEFFECT
    {
        line.SetPosition(0, startPosition);
        line.SetPosition(1, endPosition);
        line.enabled = true;
        float visualDuration = TeslaPulseItem.Instance.totalCooldown * 0.25f;
        if (visualDuration < 0.5)
        {
            visualDuration = 0.5f;
        }
        CancelInvoke(nameof(DisappearLightRay));
        Invoke(nameof(DisappearLightRay), visualDuration);
    }
    void DisappearLightRay()
    {
        line.enabled = false;
    }
}
