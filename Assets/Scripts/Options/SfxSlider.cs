using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SfxSlider : MonoBehaviour
{
    [SerializeField]
    private Audio audioData;
    public static Slider slider;

    public void Awake()
    {
        slider = GetComponent<Slider>();
        slider.value = audioData.sfxVolume;
        slider.minValue = -80f;
        slider.maxValue = 0f;
        SfxSlider.slider.value = audioData.sfxVolume;
    }
}
