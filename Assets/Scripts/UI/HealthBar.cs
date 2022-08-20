using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Player playerSO;
    private Slider healthBar;
    private RectTransform barPos;

    private float maxHealth;
    private float currentHealth;

    public void Awake()
    {
        healthBar = GetComponent<Slider>();
        barPos = GetComponent<RectTransform>();

        maxHealth = playerSO.life;
        currentHealth = maxHealth;
    }

    public void Update()
    {
        ResetHealth();
    }

    public void ResetHealth()
    {
        currentHealth = playerSO.currentLife;
        maxHealth = playerSO.life;
        healthBar.maxValue = playerSO.life;
        healthBar.value = currentHealth;
        barPos.sizeDelta = new Vector2(maxHealth, 20f);
        barPos.anchoredPosition = new Vector3(maxHealth * 0.52f, -15, 0f);
    }
}
