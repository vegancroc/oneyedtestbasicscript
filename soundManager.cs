using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{ 
    [SerializeField]
    private AudioClip landingSound;

    [SerializeField]
    private AudioClip backgroundBirds;

    [SerializeField]
    private AudioClip fireCatchSound;

    private AudioSource audioSource;

    public static soundManager Instance;

    public soundManager()
    {
        Instance = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playBackgroundSound();
    }

    public void playLandingSound(float volume)
    {
        //audioSource.clip = landingSound;
        audioSource.PlayOneShot(landingSound,volume);
    }

    public void playFireSound(float volume)
    {
        audioSource.PlayOneShot(fireCatchSound, volume);
    }

    private void playBackgroundSound()
    {
        audioSource.clip = backgroundBirds;
        audioSource.Play();
        audioSource.loop = true;
    }

}
