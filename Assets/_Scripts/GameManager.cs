using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static int level;
    
    [SerializeField] private WordsManager _wordsManager;
    [SerializeField] private Bot _bot;

    private bool _gameEnded = false;

    public Dictionary<string, string[]> words;

    private void Awake()
    {
        Instance = this;
    }

    private void LoadWords()
    {
        var text = Resources.Load("worlds") as TextAsset;
        words = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(text.text);
    }

    private void Start()
    {
        LoadWords();
        SoundManager.Instance.PlayStartRoundSound();
        string currentWorld = words.Keys.ToList()[level];
        if (level == 0)
            level = 1;
        else
            level = 0;
        _wordsManager.Init(currentWorld, words[currentWorld]);
        InputManager.Instance.Init(currentWorld);
    }

    public void EndGame(bool isPlayer)
    {
        if (!_gameEnded)
        {
            _gameEnded = true;
            if (_bot != null)
                _bot.StopAllCoroutines();
            if (!isPlayer)
            {
                UIManager.Instance.ShowLosePopup();
                SoundManager.Instance.PlayLoseSound();
            }
            else
            {
                UIManager.Instance.ShowWinPopup();
                SoundManager.Instance.PlayWindSound();
            }
        }
    }
    
}
