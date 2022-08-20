using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private Audio audioSO;

    public void Start()
    {
        SetVolume();
    }

    public void Update()
    {
        SetVolume();
    }

    public void SetVolume()
    {
        audioMixer.SetFloat("MasterSlider", audioSO.masterVolume);
        audioMixer.SetFloat("SfxSlider", audioSO.sfxVolume);
        audioMixer.SetFloat("MusicSlider", audioSO.musicVolume);
    }
}
