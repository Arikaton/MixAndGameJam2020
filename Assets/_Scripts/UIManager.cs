using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject loseWindow;
    [SerializeField] private GameObject winWindow;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowLosePopup()
    {
        loseWindow.SetActive(true);
    }

    public void ShowWinPopup()
    {
        winWindow.SetActive(true);
    }

    
}
