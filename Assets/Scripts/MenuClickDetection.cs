using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuClickDetection : MonoBehaviour
{

    Collider2D buttonCollider;
    [SerializeField] LayerMask buttonLayer;
    [SerializeField] string scene;
    Vector3 baseSize;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonCollider = GetComponent<Collider2D>();
        baseSize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D foundCollider = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()), 0.01f, buttonLayer);
        if (foundCollider != null && foundCollider == buttonCollider)
        {
            gameObject.transform.localScale = baseSize * 1.2f;
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                SceneManager.LoadScene(scene);
            }
        }
        else
        {
            gameObject.transform.localScale = baseSize;
        }
    }
}
