using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player")]
public class Player : ScriptableObject
{
    #region Player Total Values;
    public float life;
    public float lifeRecover;
    public float stamina;
    public float staminaRecover;
    #endregion

    #region Player Movements
    public float walkingSpeed;
    public float runningSpeed;
    public float jumpingForce;
    #endregion

    #region Player Attacks
    public float fistPower;
    public float kickPower;
    public float shurikenPower;
    #endregion

    #region Player Consuming
    public float runningConsuming;
    public float jumpingConsuming;
    public float fistConsuming;
    public float kickConsuming;
    public float shurikenConsuming;
    #endregion

    #region Player Equipment
    public int shuriken;
    #endregion

    #region Player Current Values
    public float currentLife;
    public float currentStamina;
    public float currentShuriken;
    public bool isDead;
    #endregion
}
