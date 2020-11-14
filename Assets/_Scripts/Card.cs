using System;
using System.Collections;
using System.Collections.Generic;
using Coffee.UIEffects;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public static Card Instance;

    [SerializeField] private Image image;
    private UIDissolve _dissolve;
    private bool _isShowing = false;

    private void Awake()
    {
        Instance = this;
    }

    public void SetImage(string cardName)
    {
        image.sprite = MapNameToSprite(cardName.ToLower());
    }

    private Sprite MapNameToSprite(string cardName)
    {
        var sprite = Resources.Load<Sprite>("Cards/" + cardName);
        Debug.Log(sprite == null);
        return sprite;
    }

    private void Start()
    {
        _dissolve = GetComponent<UIDissolve>();
    }

    public void ShowHideCard()
    {
        if (_isShowing) return;
        _isShowing = true;
        StartCoroutine(ShowHideCardCor());
    }

    IEnumerator ShowHideCardCor()
    {
        Show();
        yield return new WaitForSeconds(_dissolve.effectPlayer.duration);
        yield return new WaitForSeconds(1f);
        Hide();
        yield return new WaitForSeconds(_dissolve.effectPlayer.duration);
        _isShowing = false;
    }

    private void Show()
    {
        _dissolve.m_Reverse = true;
        _dissolve.Play();
    }

    private void Hide()
    {
        _dissolve.m_Reverse = false;
        _dissolve.Play();
    }
    
}
