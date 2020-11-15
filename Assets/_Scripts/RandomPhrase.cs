using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomPhrase : MonoBehaviour
{
    [SerializeField] private GameObject dialogWindow;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string[] phrases;

    private void Start()
    {
        dialogWindow.SetActive(false);
        StartCoroutine(ShowDialog());
    }

    IEnumerator ShowDialog()
    {
        yield return new WaitForSeconds(Random.Range(8, 15f));
        dialogWindow.SetActive(true);
        text.text = phrases[Random.Range(0, phrases.Length)];
        yield return new WaitForSeconds(4f);
        dialogWindow.SetActive(false);
        StartCoroutine(ShowDialog());
    }
}
