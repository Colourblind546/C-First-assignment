using UnityEngine;

public class RandomiseAndAppearCards : MonoBehaviour
{

    [SerializeField] CardStats[] cards;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<ExpManager>().unspentLevels > 0)
        {
            ShowCards();
        }
        else
        {
            HideCards();
        }
    }

    void ShowCards() //move cards out
    {
        
    }
    void HideCards() //move cards in
    {

    }

    [ContextMenu("TestItemSet")]
    public void SetAllCards()
    {
        Debug.Log("CArds set");
        foreach (CardStats card in cards)
        {
            int randomNumber = Random.Range(0, ItemManager.Instance.allItems.Count);
            Item item = ItemManager.Instance.allItems[randomNumber];
            card.CardStatSetter(item, item.cardType);
        }
    }
}
