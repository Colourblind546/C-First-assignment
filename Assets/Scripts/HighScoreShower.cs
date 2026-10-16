using UnityEngine;
using TMPro;

public class HighScoreShower : MonoBehaviour
{

    TMP_Text textField;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textField = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("WavesClearedHighScore"))
        {
            textField.text = $"Most waves cleared: {PlayerPrefs.GetInt("WavesClearedHighScore")}";
        }
    }


}
