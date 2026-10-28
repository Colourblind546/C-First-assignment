using UnityEngine;
using TMPro;

public class HighScoreShower : MonoBehaviour
{

    TMP_Text textField;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textField = GetComponent<TMP_Text>();

        int highScore;
        if (PlayerPrefs.HasKey("WavesClearedHighScore"))
        {
            highScore = PlayerPrefs.GetInt("WavesClearedHighScore");
        }
        else
        {
            highScore = 0;
        }
        textField.text = $"Most waves cleared: {highScore}";
    }


}
