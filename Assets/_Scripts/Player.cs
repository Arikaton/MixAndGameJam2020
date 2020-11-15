using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private bool _isRealPlayer = true;

    public void GetWord()
    {
        var word = InputManager.Instance.InputWord;
        WordsManager.Instance.EnterWorld(word);
    }

    public void GetWord(string word)
    {
        WordsManager.Instance.EnterWorld(word, false);
    }

    private void Update()
    {
        if (!_isRealPlayer) return;
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            GetWord();
        }
    }
}
