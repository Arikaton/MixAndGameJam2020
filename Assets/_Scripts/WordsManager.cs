using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class WordsManager : MonoBehaviour
{
    public static WordsManager Instance;
    
    [SerializeField] private Transform _worldsContainer;
    [SerializeField] private Transform _busyWordsContainer;
    [SerializeField] private Transform _enemyBusyWordsContainer;
    [SerializeField] private Letter _letter;
    [SerializeField] private Word _word;
    [SerializeField] private TextMeshProUGUI wordsLeftText;
    public string CurrentWorld;
    public List<string> FreeWorlds;
    public List<string> BusyWorlds;

    private List<Letter> _letters = new List<Letter>();

    private void Awake()
    {
        Instance = this;
    }

    private void UpdateWordsLeftText()
    {
        wordsLeftText.text = "Words left: " + FreeWorlds.Count;
    }

    private bool CheckWorld(string world)
    {
        return FreeWorlds.Contains(world);
    }

    public void EnterWorld(string word, bool isPlayer = true)
    {
        if (!CheckWorld(word))
        {
            SoundManager.Instance.PlayWordExistSound();
            return;
        }
        
        SoundManager.Instance.PlayWordAcceptedSound();
        FreeWorlds.Remove(word);
        BusyWorlds.Add(word);
        Word newWord;
        if (isPlayer)
        {
            newWord = Instantiate(_word, _busyWordsContainer);
            SoundManager.Instance.PlayWordAcceptedSound();
        }
        else
        {
            newWord = Instantiate(_word, _enemyBusyWordsContainer);
            if (_enemyBusyWordsContainer.childCount - _busyWordsContainer.childCount >= 2)
                SoundManager.Instance.PlayTikTakSound();
            SoundManager.Instance.PlayOpponentAccepted();
        }

        newWord.Init(word);
        if (isPlayer)
            InputManager.Instance.Clear();
        Card.Instance.SetImage(word, isPlayer);
        UpdateWordsLeftText();
    }

    public void Init(string world, string[] freeWorlds)
    {
        foreach (var letter in world)
        {
            Letter letterObj = Instantiate(_letter, _worldsContainer);
            _letters.Add(letterObj);
            letterObj.Init(letter.ToString());
            
        }
        CurrentWorld = world;
        FreeWorlds = freeWorlds.ToList();
        UpdateWordsLeftText();
    }
}
