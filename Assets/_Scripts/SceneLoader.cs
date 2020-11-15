using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject developersWindow;
    [SerializeField] private GameObject rulesWindow;
    
    public void LoadGame()
    {
        SceneManagerExtension.Main.LoadGameScene();
    }

    public void LoadMenu()
    {
        SceneManagerExtension.Main.LoadStartScene();
    }

    public void ShowHideRules()
    {
        rulesWindow.SetActive(!rulesWindow.activeSelf);
    }

    public void ShowHideDevelopers()
    {
        developersWindow.SetActive(!developersWindow.activeSelf);
    }

    public void OpenLink(string link)
    {
        Application.OpenURL(link);
    }
}
