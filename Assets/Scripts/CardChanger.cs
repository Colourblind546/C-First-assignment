using UnityEngine;

public class CardChanger : MonoBehaviour
{

    [SerializeField] Sprite[] cardSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCard(int index)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = cardSprite[index];
    }
}
