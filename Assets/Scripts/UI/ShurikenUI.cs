using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShurikenUI : MonoBehaviour
{
    [SerializeField]
    private Player playerSO;
    private TextMeshProUGUI textUI;

    public void Start()
    {
        textUI = GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        textUI.text = "Shuriken: " + (playerSO.currentShuriken).ToString();
    }
}
