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
                ItemManager.Instance.AddItem(gameObject.GetComponent<CardStats>().cardItem);
            }
        }
        else
        {
            gameObject.transform.transform.localScale = Vector3.one * 5;
        }
    }

    


}
