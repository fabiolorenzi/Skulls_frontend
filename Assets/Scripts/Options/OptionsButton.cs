using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    [SerializeField]
    private Audio audioData;

    public void ResetValue()
    {
        audioData.masterVolume = -10f;
        audioData.sfxVolume = 0f;
        audioData.musicVolume = -25f;
        MasterSlider.slider.value = audioData.masterVolume;
        SfxSlider.slider.value = audioData.sfxVolume;
        MusicSlider.slider.value = audioData.musicVolume;
    }

    public void SaveValue()
    {
        audioData.masterVolume = MasterSlider.slider.value;
        audioData.sfxVolume = SfxSlider.slider.value;
        audioData.musicVolume = MusicSlider.slider.value;
    }
}
