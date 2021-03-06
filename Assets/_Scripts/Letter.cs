﻿using System;
using System.Collections;
using System.Collections.Generic;
using Coffee.UIEffects;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Letter : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public enum LetterAction{ Add, Remove}

    public float EffectDuration => _shineEffect.effectPlayer.duration;
    [SerializeField] private Color interactColor;

    private Color startColor = Color.black;
    private LetterAction _letterAction = LetterAction.Add;
    private TextMeshProUGUI text;
    private UIShiny _shineEffect;
    private string _letter;

    public void Init(string letter, LetterAction letterAction = LetterAction.Add)
    {
        _shineEffect = GetComponent<UIShiny>();
        _letter = letter;
        _letterAction = letterAction;
        text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = letter.ToUpper();
        text.color = startColor;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        SoundManager.Instance.PlayLetterSound();
        if (_letterAction == LetterAction.Add)
            InputManager.Instance.AddLetter(_letter);
        else
            InputManager.Instance.RemoveLetter(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = interactColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = startColor;
    }
}
