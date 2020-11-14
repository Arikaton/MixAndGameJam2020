using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float health;
    private bool _isRealPlayer = true;

    private void Start()
    {
        health = GameData.Instance.maxHealth;
        UIManager.Instance.SetHealth(health, _isRealPlayer);
    }

    public void GetDamage(float damage)
    {
        PlayDamageVFX();
        health -= damage;
        UIManager.Instance.SetHealth(health);
        if (health <= 0)
        {
            GameManager.Instance.LoseGame();
            PlayDeathAnim();
        }
    }

    public void GetHealth(float h)
    {
        health += h;
        if (health > GameData.Instance.maxHealth)
            health = GameData.Instance.maxHealth;
    }

    public void PlayDamageVFX()
    {
        
    }

    public void PlayDeathAnim()
    {
        
    }
}
