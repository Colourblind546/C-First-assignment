using TMPro;
using UnityEngine;

public class CardStats : MonoBehaviour
{

    
    [SerializeField] TMP_Text description;
    [SerializeField] TMP_Text stats;
    [SerializeField] TMP_Text stacks;
    [SerializeField] GameObject card;
    [SerializeField] SpriteRenderer icon;
    public Item cardItem;
    CardChanger cardChanger;

    private void Awake()
    {
        cardChanger = card.GetComponent<CardChanger>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CardStatSetter(Item item, int cardType)
    {
        description.text = item.description;
        stats.text = item.scalingInformation;
        icon.sprite = item.icon;
        cardItem = item;
        if (item.stacks != 0)
        {
            stacks.text = $"({item.stacks})";
        }
        else
        {
            stacks.text = "";
        }

            card.GetComponent<CardChanger>().SetCard(cardType);

    }
}
