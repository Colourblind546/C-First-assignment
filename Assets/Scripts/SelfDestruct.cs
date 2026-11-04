using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelfDestructSequence(float destroySelfInSeconds)
    {
        Invoke(nameof(DestroySelf), destroySelfInSeconds);
    }
    public void SelfDisableSequence(float destroySelfInSeconds)
    {
        Invoke(nameof(DisableSelf), destroySelfInSeconds);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
    void DisableSelf()
    {
        gameObject.SetActive(false);
    }
}
