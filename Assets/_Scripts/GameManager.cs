using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : SerializedMonoBehaviour
{
    [SerializeField] private WordsManager _wordsManager;

    [ShowInInspector]
    public Dictionary<string, string[]> words = new Dictionary<string, string[]>();

    [Button]
    public void Save()
    {
        string serialized = JsonConvert.SerializeObject(words);
        File.WriteAllText(Application.streamingAssetsPath + "/worlds.txt", serialized);
    }

    [Button]
    public void Load()
    {
        string text = File.ReadAllText(Application.streamingAssetsPath + "/worlds.txt");
        words = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(text);
    }

    private void Start()
    {
        if (words.Count == 0)
            Load();
        string currentWorld = words.Keys.ToList()[Random.Range(0, words.Count)];
        _wordsManager.Init(currentWorld, words[currentWorld]);
        InputManager.Instance.Init(currentWorld);
    }
}
