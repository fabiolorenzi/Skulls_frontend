using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField]
    private Player playerSO;
    [SerializeField]
    private AudioSource audioPlayerDeath;
    [SerializeField]
    private AudioSource audioPlayerHurt;
    private Animator playerAnim;

    public void Awake()
    {
        playerAnim = GetComponentInChildren<Animator>();
        playerSO.isDead = false;
    }

    public void LateUpdate()
    {
        playerAnim.SetBool("isHurt", false);
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 6 && EnemyAttack.isAttacking)
        {
            if (playerSO.currentLife - EnemyAttack.attackPower > 0)
            {
                playerAnim.SetBool("isHurt", true);
                playerSO.currentLife -= EnemyAttack.attackPower;
                audioPlayerHurt.Play();
            }
            else
            {
                playerSO.currentLife = 0;
                Death();
            }
        }
    }

    public void Death()
    {
        playerAnim.SetBool("isDead", true);

        if (!playerSO.isDead)
        {
            audioPlayerDeath.Play();
        }
        playerSO.isDead = true;
    }
}
