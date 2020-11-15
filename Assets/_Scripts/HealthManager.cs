using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;
    
    [SerializeField] private Health playerHealth;
    [SerializeField] private Health enemyHealth;

    private void Awake()
    {
        Instance = this;
    }

    public void ProvideDamage(float damage, bool isPlayer)
    {
        if (!isPlayer)
        {
            playerHealth.GetDamage(damage, isPlayer);
        }
        else
        {
            enemyHealth.GetDamage(damage, isPlayer);
        }
    }
}
