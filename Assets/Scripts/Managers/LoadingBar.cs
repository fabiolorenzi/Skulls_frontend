using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    [SerializeField]
    private Slider bar;

    public static float current;

    public void Awake()
    {
        bar = GetComponent<Slider>();
    }

    public void Update()
    {
        bar.value = current;
    }
}
