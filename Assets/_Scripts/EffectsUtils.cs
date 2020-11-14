using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsUtils : MonoBehaviour
{
    public static EffectsUtils Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayEffectsForLetter(List<Letter> letters)
    {
        StartCoroutine(PlayEffectsForLetterCor(letters));
    }
    
    IEnumerator PlayEffectsForLetterCor(List<Letter> letters)
    {
        yield return new WaitForSeconds(1);
        foreach (var letter in letters)
        {
            yield return new WaitForSeconds(letter.EffectDuration - 0.2f);
        }
    }
}
