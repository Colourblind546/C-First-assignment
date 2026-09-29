using TMPro;
using UnityEngine;

public class CardStats : MonoBehaviour
{

    
    [SerializeField] TMP_Text description;
    [SerializeField] TMP_Text stats;
    [SerializeField] GameObject card;
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

    void CardSetter(Item item)
    {

        description.text = item.Instance.description;
        stats.text = item.Instance.ScalingInformation;



    }
}
