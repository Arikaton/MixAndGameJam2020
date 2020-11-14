using System;
using System.Collections;
using System.Collections.Generic;
using Coffee.UIEffects;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Letter : MonoBehaviour, IPointerClickHandler
{
    public enum LetterAction{ Add, Remove}

    public float EffectDuration => _shineEffect.effectPlayer.duration;

    private LetterAction _letterAction = LetterAction.Add;
    private TextMeshProUGUI text;
    private UIShiny _shineEffect;
    protected string _letter;

    public void Init(string letter, LetterAction letterAction = LetterAction.Add)
    {
        _shineEffect = GetComponent<UIShiny>();
        _letter = letter;
        _letterAction = letterAction;
        text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = letter.ToUpper();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_letterAction == LetterAction.Add)
            InputManager.Instance.AddLetter(_letter);
        else
            InputManager.Instance.RemoveLetter(this);
    }

    public void PlayEffect()
    {
        _shineEffect.Play();
    }
}
