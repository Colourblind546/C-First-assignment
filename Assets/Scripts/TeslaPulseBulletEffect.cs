using UnityEngine;

public class TeslaPulseBulletEffect : MonoBehaviour
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
        if (material.color.a > 0)
        {
            fadeAmount -= Time.deltaTime / lifeTime;
            Debug.Log($"Fade amounte: {fadeAmount}");
            Color color = new Color(1, 1, 1, fadeAmount);
            material.SetColor("_BaseColor", color);
        }
    }

    [ContextMenu("Appear")]
    public void AppearTeslaPulseEffect(/*Vector2 startPosition, Vector2 endPosition*/)
    {
        line.SetPosition(0, Vector2.up);
        line.SetPosition(1, Vector2.down);
        material.SetColor("_BaseColor", Color.white);
    }
}
