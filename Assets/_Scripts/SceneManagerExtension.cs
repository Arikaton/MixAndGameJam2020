using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerExtension : MonoBehaviour
{
    public static SceneManagerExtension Main;
    public const string GameScene = "GameScene";
    public const string MenuScene = "MenuScene";

    [SerializeField] [Range(0, 3f)] private float fadeSpeed;
    
    private CanvasGroup _canvasGroup;
    private bool _isLoadingScene = false;

    private void Awake()
    {
        if (FindObjectsOfType<SceneManagerExtension>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            Main = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        _canvasGroup = GetComponentInChildren<CanvasGroup>();
    }

    public void LoadGameScene()
    {
        LoadSceneWithFadeEffect(GameScene);
    }

    public void LoadStartScene()
    {
        LoadSceneWithFadeEffect(MenuScene);
    }

    public void LoadSceneWithFadeEffect(string sceneName)
    {
        if (_isLoadingScene) return;
        _isLoadingScene = true;
        StartCoroutine(LoadSceneWithFadeEffectCor(sceneName));
    }

    IEnumerator LoadSceneWithFadeEffectCor(string sceneName)
    {
        Debug.Log("Start loading scene");
        SceneManager.sceneLoaded += OnSceneLoaded;
        yield return StartCoroutine(FadeInCor());
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator FadeInCor()
    {
        for (float i = 0; i < 1; i += 0.01f)
        {
            _canvasGroup.alpha = i;
            yield return new WaitForSeconds(fadeSpeed / 100);
        }
    }

    IEnumerator FadeOutCor()
    {
        for (float i = 1; i > 0; i -= 0.01f)
        {
            _canvasGroup.alpha = i;
            yield return new WaitForSeconds(fadeSpeed / 100);
        }
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        StartCoroutine(FadeOutCor());
        SceneManager.sceneLoaded -= OnSceneLoaded;
        _isLoadingScene = false;
    }
}
