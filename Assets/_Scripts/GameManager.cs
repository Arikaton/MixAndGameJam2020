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
    public static GameManager Instance;
    
    [SerializeField] private WordsManager _wordsManager;

    [ShowInInspector]
    public Dictionary<string, string[]> words = new Dictionary<string, string[]>();

    private void Awake()
    {
        Instance = this;
    }

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

    public void LoseGame()
    {
        
    }

    public void WinGame()
    {
        
    }
}
