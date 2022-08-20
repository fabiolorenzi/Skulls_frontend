using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterSlider : MonoBehaviour
{
    [SerializeField]
    private Audio audioData;
    public static Slider slider;

    public void Awake()
    {
        slider = GetComponent<Slider>();
        slider.value = audioData.masterVolume;
        slider.minValue = -80f;
        slider.maxValue = 3f;
        MasterSlider.slider.value = audioData.masterVolume;
    }
}
