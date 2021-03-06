﻿using System.Collections;
using System.Collections.Generic;
using Coffee.UIEffects;
using TMPro;
using UnityEngine;

public class Word : MonoBehaviour
{
    private TextMeshProUGUI text;
    public string CurrentWord;

    public void Init(string word)
    {
        CurrentWord = word;
        text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = word.ToUpper();
    }
}
