using UnityEngine;

public class Experience : MonoBehaviour
{

    [SerializeField] private int expValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        expValue = Mathf.CeilToInt((float)(expValue * GameManager.Instance.difficultyModifier));
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
