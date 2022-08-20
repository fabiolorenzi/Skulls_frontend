using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Player playerSO;

    private float totHealth = 100f;
    private float health;

    public void Awake()
    {
        playerSO.life = totHealth;
        health = totHealth;
        playerSO.currentLife = health;
        playerSO.isDead = false;
    }

    public void Update()
    {
        totHealth = playerSO.life;
    }
}
