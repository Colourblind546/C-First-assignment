using UnityEngine;

public class Experience : MonoBehaviour
{

    [SerializeField] private int expValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public int GetExp()
    {
        return expValue;
    }
}
