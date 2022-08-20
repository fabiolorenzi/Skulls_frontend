using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField]
    private Player playerSO;
    private Slider staminaBar;
    private RectTransform barPos;

    private float maxStamina;
    private float currentStamina;

    public void Awake()
    {
        staminaBar = GetComponent<Slider>();
        barPos = GetComponent<RectTransform>();

        maxStamina = playerSO.stamina;
        currentStamina = maxStamina;
    }

    public void Start()
    {
        ResetStamina();
    }

    public void Update()
    {
        UpdateBar();
    }

    public void ResetStamina()
    {
        currentStamina = playerSO.currentStamina;
        staminaBar.maxValue = playerSO.stamina;
        staminaBar.value = currentStamina;
        barPos.sizeDelta = new Vector2(maxStamina, 20f);
        barPos.anchoredPosition = new Vector3(maxStamina * 0.52f, -25f, 0f);
    }

    public void UpdateBar()
    {
        currentStamina = playerSO.currentStamina;
        staminaBar.value = currentStamina;
    }
}
