using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI text;
    
    private float _health;

    private void Start()
    {
        _health = GameData.Instance.maxHealth;
        SetHealth();
    }

    public void SetHealth()
    {
        var healthPercent = _health / GameData.Instance.maxHealth;
        if (healthPercent > 0.5f)
        {
            image.color = new Color(2 - 2 * healthPercent, 1, 0);
        }
        else
        {
            image.color = new Color(1, (healthPercent * 2), 0);
        }
        text.text = _health.ToString();
    }

    public void GetDamage(float damage, bool isPlayer)
    {
        _health -= damage;
        if (_health <= 0)
        {
            GameManager.Instance.EndGame(isPlayer);
        }
        SetHealth();
    }
}
