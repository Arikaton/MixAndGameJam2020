using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private Slider playerHealthSlider;
    [SerializeField] private Slider enemyHealthSlider;

    private float maxPlayerHealth;

    public void Start()
    {
        maxPlayerHealth = GameData.Instance.maxHealth;
        playerHealthSlider.maxValue = maxPlayerHealth;
        enemyHealthSlider.maxValue = maxPlayerHealth;
    }

    public void SetHealth(float health, bool player = true)
    {
        var healthSlider = player ? playerHealthSlider : enemyHealthSlider;
        healthSlider.value = health;
    }
}
