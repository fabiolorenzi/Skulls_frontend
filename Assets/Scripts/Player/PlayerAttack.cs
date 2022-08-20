using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Player playerData;
    private Animator playerAnim;
    [SerializeField]
    private AudioSource audioPlayer;

    public static bool firstAttack = false;
    public static bool secondAttack = false;
    public static bool thirdAttack = false;
    private bool attackTime = false;

    public void Awake()
    {
        playerAnim = GetComponentInChildren<Animator>();
    }

    public void Update()
    {
        AttackSeq();
    }

    public IEnumerator AttackTime()
    {
        yield return new WaitForSeconds(2f);
        attackTime = false;
        firstAttack = false;
        secondAttack = false;
        thirdAttack = false;
        playerAnim.ResetTrigger("firstAttack");
        playerAnim.ResetTrigger("secondAttack");
        playerAnim.ResetTrigger("thirdAttack");
    }

    public void AttackSeq()
    {
        if (!playerData.isDead)
        {
            if (Input.GetMouseButtonUp(0) && !firstAttack && !attackTime && playerData.currentStamina >= playerData.fistConsuming)
            {
                firstAttack = true;
                playerAnim.SetTrigger("firstAttack");
                attackTime = true;
                playerData.currentStamina -= playerData.fistConsuming;
                audioPlayer.Play();
                StartCoroutine(AttackTime());
            }
            else if (Input.GetMouseButtonUp(0) && !secondAttack && attackTime && playerData.currentStamina >= playerData.fistConsuming)
            {
                secondAttack = true;
                playerAnim.SetTrigger("secondAttack");
                playerData.currentStamina -= playerData.fistConsuming;
                audioPlayer.Play();
            }
            else if (Input.GetMouseButtonUp(0) && !thirdAttack && attackTime && playerData.currentStamina >= playerData.kickConsuming)
            {
                thirdAttack = true;
                playerAnim.SetTrigger("thirdAttack");
                playerData.currentStamina -= playerData.kickConsuming;
                audioPlayer.Play();
            }
        }
    }
}
