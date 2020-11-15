using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private bool playBackgroundMusic;
    [SerializeField] private AudioClip[] letterSounds;
    [SerializeField] private AudioClip[] backgroundsMusic;
    [SerializeField] private AudioClip[] cardSounds;
    [SerializeField] private AudioClip[] opponentSounds;
    [SerializeField] private AudioClip[] wordAcceptedSound;
    [SerializeField] private AudioClip[] wordExistSounds;
    [SerializeField] private AudioClip[] hitSounds;
    [SerializeField] private AudioClip tiktakSound;
    [SerializeField] private AudioClip startSound;
    [SerializeField] private AudioClip startRoundSound;
    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioClip loseSound;
    [SerializeField] private AudioSource effectsAudioSource;
    [SerializeField] private AudioSource musicAudioSource;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (playBackgroundMusic)
        {
            PlayBackgroundMusic();
        }
    }

    public void PlayTikTakSound()
    {
        effectsAudioSource.PlayOneShot(tiktakSound);
    }

    public void PlayHitSound()
    {
        effectsAudioSource.PlayOneShot(GetRandomSound(hitSounds));
    }

    public void PlayWindSound()
    {
        effectsAudioSource.PlayOneShot(winSound);
    }

    public void PlayLoseSound()
    {
        effectsAudioSource.PlayOneShot(loseSound);
    }

    private void PlayBackgroundMusic()
    {
        musicAudioSource.clip = GetRandomSound(backgroundsMusic);
        musicAudioSource.Play();
    }

    private void Update()
    {
        if (playBackgroundMusic)
        {
            if (!musicAudioSource.isPlaying)
            {
                PlayBackgroundMusic();
            }
        }
    }

    public void PlayWordAcceptedSound()
    {
        effectsAudioSource.PlayOneShot(GetRandomSound(wordAcceptedSound));
    }

    public void PlayWordExistSound()
    {
        effectsAudioSource.PlayOneShot(GetRandomSound(wordExistSounds));
    }

    public void PlayStartRoundSound()
    {
        effectsAudioSource.PlayOneShot(startRoundSound);
    }

    public void PlayOpponentAccepted()
    {
        effectsAudioSource.PlayOneShot(GetRandomSound(opponentSounds));
    }

    public void CardAppereance()
    {
        effectsAudioSource.PlayOneShot(GetRandomSound(cardSounds));
    }

    public void PlayStartSound()
    {
        effectsAudioSource.clip = startSound;
        effectsAudioSource.Play();
    }

    public void PlayLetterSound()
    {
        effectsAudioSource.clip = GetRandomSound(letterSounds);
        effectsAudioSource.Play();
    }

    private AudioClip GetRandomSound(AudioClip[] clips)
    {
        return clips[Random.Range(0, clips.Length)];
    }
}
