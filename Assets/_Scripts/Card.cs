using System;
using System.Collections;
using System.Collections.Generic;
using Coffee.UIEffects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Card : MonoBehaviour
{
    public static Card Instance;

    [SerializeField] private Image image;
    [SerializeField] private Transform playerAvatar;
    [SerializeField] private Transform enemyAvatar;
    [SerializeField] private float moveSpeed;

    private Vector3 _startPos;
    private TextMeshProUGUI text;
    private CanvasGroup _textCanvasGroup;
    private UIDissolve _dissolve;
    private bool _isShowing = false;
    private Queue<string> _queue = new Queue<string>();
    private Queue<bool> _playerQueue = new Queue<bool>();

    private void Awake()
    {
        Instance = this;
    }

    public void SetImage(string cardName, bool isPlayer)
    {
        if (_isShowing)
        {
            _queue.Enqueue(cardName);
            _playerQueue.Enqueue(isPlayer);
        }
        else
        {
            SoundManager.Instance.CardAppereance();
            image.sprite = MapNameToSprite(cardName.ToLower());
            text.text = cardName.Length.ToString();
            ShowHideCard(isPlayer);
        }
    }

    private Sprite MapNameToSprite(string cardName)
    {
        var sprite = Resources.Load<Sprite>("Cards/" + cardName);
        return sprite;
    }

    private void Start()
    {
        _dissolve = GetComponent<UIDissolve>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        _textCanvasGroup = GetComponentInChildren<CanvasGroup>();
        _startPos = transform.position;
    }

    public void ShowHideCard(bool isPLayer)
    {
        if (_isShowing) return;
        transform.position = _startPos;
        transform.localScale = Vector3.one;
        _isShowing = true;
        StartCoroutine(ShowHideCardCor(isPLayer));
    }

    private void Update()
    {
        if (_isShowing)
        {
            _textCanvasGroup.alpha = 1 - _dissolve.effectFactor;
        }
    }

    IEnumerator ShowHideCardCor(bool isPLayer)
    {
        Show();
        yield return new WaitForSeconds(_dissolve.effectPlayer.duration);
        yield return StartCoroutine(MoveToAim(isPLayer));
        Hide();
        yield return new WaitForSeconds(_dissolve.effectPlayer.duration);
        _isShowing = false;
        if (_queue.Count != 0)
        {
            SetImage(_queue.Dequeue(), _playerQueue.Dequeue());
        }
    }

    IEnumerator MoveToAim(bool isPlayer)
    {
        SoundManager.Instance.PlayHitSound();
        var aim = isPlayer ? enemyAvatar : playerAvatar;
        transform.DOMove(aim.position, 1).SetEase(Ease.InOutSine);
        yield return new WaitForSeconds(0.4f);
        transform.DOScale(Vector3.one * 0.4f, 0.5f).SetEase(Ease.InCubic);
        yield return new WaitForSeconds(0.4f);
        HealthManager.Instance.ProvideDamage(int.Parse(text.text), isPlayer);
        aim.DOShakePosition(0.3f, Vector3.one * 30);
        aim.DOShakeRotation(0.3f, Vector3.one * 30);
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
