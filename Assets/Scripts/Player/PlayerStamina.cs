using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    public Player playerSO;

    private float totStamina;
    private float stamina;

    public void Awake()
    {
        totStamina = playerSO.stamina;
        playerSO.currentStamina = playerSO.stamina;
        stamina = totStamina;
    }

    public void Update()
    {
        if (playerSO.currentStamina < playerSO.stamina)
        {
            GrowStamina();
        }
    }

    public void GrowStamina()
    {
        playerSO.currentStamina += playerSO.staminaRecover * Time.deltaTime;
    }
}
