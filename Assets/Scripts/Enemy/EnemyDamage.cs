using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]
    private Player playerSO;
    private Animator enemyAnim;
    [SerializeField]
    private AudioSource audioPlayer;

    [SerializeField]
    private float enemyHealth = 500f;

    public void Awake()
    {
        enemyAnim = GetComponent<Animator>();
    }

    public void Start()
    {
        enemyAnim.SetBool("isDead", false);
    }

    public void LateUpdate()
    {
        enemyAnim.SetBool("isHit", false);
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            GetHit(playerSO.shurikenPower);
        }
        else if (collision.gameObject.layer == 7 && PlayerAttack.thirdAttack)
        {
            GetHit(playerSO.kickPower);
        }
        else if (collision.gameObject.layer == 7 && (PlayerAttack.firstAttack || PlayerAttack.secondAttack))
        {
            GetHit(playerSO.fistPower);
        }
    }

    public IEnumerator RemoveDead()
    {
        audioPlayer.Play();
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    private void GetHit(float damage)
    {
        if (enemyHealth - damage > 0)
        {
            enemyHealth -= damage;
            enemyAnim.SetBool("isHit", true);
        }
        else
        {
            enemyHealth = 0f;
            enemyAnim.SetBool("isDead", true);
            PointsUI.SetPoints(50);
            StartCoroutine(RemoveDead());
        }
    }
}
