using TMPro;
using UnityEngine;

public class RandomiseAndAppearCards : MonoBehaviour
{

    [SerializeField] CardStats[] cards;
    [SerializeField] GameObject cardsParent;

    [SerializeField] TMP_Text levelDisplay;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int unspentLevels = GameObject.FindGameObjectWithTag("Player").GetComponent<ExpManager>().unspentLevels;

        levelDisplay.text = $"Levels: {unspentLevels}";

        if (unspentLevels > 0)
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
        float moveOutDistance = -12;
        if (cardsParent.transform.localPosition.x < moveOutDistance)
        {
            cardsParent.transform.position += Vector3.right * Time.deltaTime * 35;
            if (cardsParent.transform.localPosition.x > moveOutDistance)
            {
                cardsParent.transform.localPosition = new Vector3(moveOutDistance, -1, 15);
            }
        }
    }
    void HideCards() //move cards in
    {
        float moveInDistance = -25;
        if (cardsParent.transform.localPosition.x > moveInDistance)
        {
            cardsParent.transform.position += Vector3.left * Time.deltaTime * 35;
            if (cardsParent.transform.localPosition.x < moveInDistance)
            {
                cardsParent.transform.localPosition = new Vector3(moveInDistance, -1, 15);
            }
        }
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
