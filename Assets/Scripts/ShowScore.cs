using TMPro;
using UnityEngine;

public class ShowScore : MonoBehaviour
{

    TMP_Text textField;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textField = GetComponent<TMP_Text>();
        textField.text = $"Waves cleared: {GameManager.Instance.wave}";
        Destroy(GameManager.Instance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
