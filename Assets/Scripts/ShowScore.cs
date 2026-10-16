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
        int highScore;
        int score = GameManager.Instance.wave;
        if (PlayerPrefs.HasKey("WavesClearedHighScore"))
        {
            highScore = PlayerPrefs.GetInt("WavesClearedHighScore");
        }
        else
        {
            highScore = 0;
        }

        if (score > highScore)
        {
            PlayerPrefs.SetInt("WavesClearedHighScore", score);
        }
        Destroy(GameManager.Instance);
    }
}
