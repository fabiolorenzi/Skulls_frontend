using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioPlayer;
    [SerializeField]
    private Player playerSO;
    [SerializeField]
    private GameObject throwDirection;
    [SerializeField]
    private GameObject shuriken;
    private Animator playerAnim;

    private float speed = 5f;
    private float distance = 20000f;

    public void Awake()
    {
        playerAnim = GetComponentInChildren<Animator>();
        playerSO.currentShuriken = 10;
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            Shoot();
        }
    }

    public void LateUpdate()
    {
        playerAnim.ResetTrigger("throw");
    }

    public void Shoot()
    {
        if (playerSO.currentShuriken > 0)
        {
            audioPlayer.Play();
            playerAnim.SetTrigger("throw");
            RaycastHit hit;
            if (Physics.Raycast(throwDirection.transform.position, throwDirection.transform.forward, out hit, distance))
            {
                GameObject tempShur = Instantiate(shuriken, throwDirection.transform.position, Quaternion.LookRotation(throwDirection.transform.forward));
                tempShur.GetComponent<Shuriken>().speed = speed;
                tempShur.GetComponent<Shuriken>().hitPoint = hit.point;
                playerSO.currentShuriken--;
                playerSO.currentStamina -= playerSO.shurikenConsuming;
            }
        }
    }
}
