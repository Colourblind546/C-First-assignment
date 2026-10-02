using UnityEngine;
using UnityEngine.InputSystem;

public class ClickDetection : MonoBehaviour
{

    Collider2D buttonCollider;
    [SerializeField] LayerMask buttonLayer;

    private void Awake()
    {
        buttonCollider = GetComponent<Collider2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D foundCollider = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()), 0.01f, buttonLayer);
        if (foundCollider != null && foundCollider == buttonCollider)
        {
            gameObject.transform.transform.localScale = Vector3.one * 6;
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                GameObject clickTarget = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()), 0.01f, buttonLayer).gameObject;
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<ExpManager>().unspentLevels > 0)
                {
                    ItemManager.Instance.AddItem(gameObject.GetComponent<CardStats>().cardItem);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<ExpManager>().unspentLevels--;
                    Camera.main.gameObject.GetComponent<RandomiseAndAppearCards>().SetAllCards();
                }
            }
        }
        else
        {
            gameObject.transform.transform.localScale = Vector3.one * 5;
        }
    }

    


}
