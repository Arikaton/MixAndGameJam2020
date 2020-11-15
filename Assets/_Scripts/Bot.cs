using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bot : MonoBehaviour
{
    [SerializeField] private float minTimeBeetweenGetWord;
    [SerializeField] private float maxTimeBetweenGetWord;

    private Player _player;
    
    private void Start()
    {
        _player = GetComponent<Player>();
        StartCoroutine(GameCycle());
    }

    IEnumerator GameCycle()
    {
        yield return new WaitForSeconds(Random.Range(minTimeBeetweenGetWord, maxTimeBetweenGetWord));
        _player.GetWord(WordsManager.Instance.FreeWorlds[Random.Range(0, WordsManager.Instance.FreeWorlds.Count)]);
        SoundManager.Instance.PlayOpponentAccepted();
        StartCoroutine(GameCycle());
    }
}
