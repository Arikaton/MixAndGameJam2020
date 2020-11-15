using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

public class EditJsonEditor : OdinEditorWindow
{
    [ShowInInspector]
    public Dictionary<string, string[]> words = new Dictionary<string, string[]>();

    [MenuItem("Window/Edit words json")]
    public static void CreateWindow()
    {
        var window = GetWindow<EditJsonEditor>();
        window.Show();
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
}
