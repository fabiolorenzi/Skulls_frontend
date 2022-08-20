using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    [SerializeField]
    private Audio audioData;
    public static Slider slider;

    public void Awake()
    {
        slider = GetComponent<Slider>();
        slider.value = audioData.musicVolume;
        slider.minValue = -80f;
        slider.maxValue = 0f;
        MusicSlider.slider.value = audioData.musicVolume;
    }
}
