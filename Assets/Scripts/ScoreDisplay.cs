using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{

    TMP_Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Wave {GameManager.Instance.wave+1}";
    }
}
