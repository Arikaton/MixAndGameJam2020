using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public string InputWord => _inputWord;
    
    [SerializeField] private int capacity;
    [SerializeField] private Transform inputWordsContainer;
    [SerializeField] private Letter letterObj;
    private string _inputWord = "";
    private List<Letter> _letters;

    private void Awake()
    {
        Instance = this;
    }

    public void Clear()
    {
        foreach (var letter in _letters)
        {
            letter.gameObject.SetActive(false);
        }

        _inputWord = "";
    }

    public void Init(string word)
    {
        _letters = new List<Letter>(word.Length);
        for (int i = 0; i < word.Length; i++)
        {
            var newLetter = Instantiate(letterObj, inputWordsContainer);
            _letters.Add(newLetter);
            newLetter.gameObject.SetActive(false);
        }
    }

    public void AddLetter(string letter)
    {
        if (_inputWord.Length >= capacity) return;
        _inputWord += letter;
        var currentLetter = _letters[_inputWord.Length - 1];
        currentLetter.gameObject.SetActive(true);
        currentLetter.Init(letter, Letter.LetterAction.Remove);
    }

    public void RemoveLetter(Letter letterObj)
    {
        if (_inputWord == "")
            return;
        var letterIndex = _letters.IndexOf(letterObj);
        var currentLetter = _letters[letterIndex];
        currentLetter.transform.SetAsLastSibling();
        _letters.Remove(currentLetter);
        _letters.Add(currentLetter);
        currentLetter.gameObject.SetActive(false);
        _inputWord = _inputWord.Remove(letterIndex, 1);
    }
}
