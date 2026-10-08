using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health;
    public int maxHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            // Do the die
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
