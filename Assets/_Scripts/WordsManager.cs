using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordsManager : MonoBehaviour
{
    [SerializeField] private Transform _worldsContainer;
    [SerializeField] private Transform _busyWordsContainer;
    [SerializeField] private Letter _letter;
    [SerializeField] private Word _word;
    public string CurrentWorld;
    public List<string> FreeWorlds;
    public List<string> BusyWorlds;

    private List<Letter> _letters = new List<Letter>();

    public bool CheckWorld(string world)
    {
        return FreeWorlds.Contains(world);
    }

    public void EnterWorld()
    {
        var word = InputManager.Instance.InputWord;
        if (CheckWorld(word))
        {
            FreeWorlds.Remove(word);
            BusyWorlds.Add(word);
            var newWord = Instantiate(_word, _busyWordsContainer);
            newWord.Init(word);
            newWord.PlayEffect();
            InputManager.Instance.Clear();
        }
    }

    IEnumerator PlayEffectsForLetter()
    {
        yield return new WaitForSeconds(1);
        foreach (var letter in _letters)
        {
            letter.PlayEffect();
            yield return new WaitForSeconds(letter.EffectDuration - 0.2f);
        }
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
        
        StartCoroutine(PlayEffectsForLetter());
    }
}
