using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    private AudioSource audioPlayer;

    public AudioClip hoverSound;
    public AudioClip acceptSound;

    public void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound)
    {
        audioPlayer.PlayOneShot(sound);
    }
}
