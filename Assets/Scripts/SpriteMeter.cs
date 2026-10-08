using System;
using UnityEngine;

public class SpriteMeter : MonoBehaviour
{

    enum MeterType
    {
        Exp, Health,
    }

    [SerializeField] public SpriteMeterParams[] meterState;
    SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }



    [SerializeField] MeterType meterType;
    // Update is called once per frame
    void Update()
    {
        float upperValue = 0;
        float value = 0;
        switch (meterType)
        {
            case MeterType.Exp:
                {
                    ExpManager playerExp = GameObject.FindGameObjectWithTag("Player").GetComponent<ExpManager>();
                    upperValue = playerExp.expToLevel;
                    value = playerExp.currentExp;
                    break;
                }
            case MeterType.Health:
                {
                    PlayerHealth playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
                    upperValue = playerHealth.maxHealth;
                    value = playerHealth.health;
                    break;
                }
        }
        float percentageOfMax = (value / upperValue) * 100;

        SetSpriteBasedOnPercentage(percentageOfMax);

    }

    void SetSpriteBasedOnPercentage(float percentage)
    {
        foreach (SpriteMeterParams spriteMeterParams in meterState)
        {
            if (percentage > spriteMeterParams.moreThanPercentage)
            {
                spriteRenderer.sprite = spriteMeterParams.sprite;
            }
        }
        if (percentage == 0)
        {
            spriteRenderer.sprite = meterState[0].sprite;
        }
    }
}

[Serializable]
public class SpriteMeterParams
{
    [SerializeField] public float moreThanPercentage;
    [SerializeField] public Sprite sprite;
}
