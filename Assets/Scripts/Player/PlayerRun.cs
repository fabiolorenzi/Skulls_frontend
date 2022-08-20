using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    public Player playerSO;
    private Animator playerAnim;

    private float sprintSpeed;
    private float walkingSpeed;
    private bool isRunning = false;
    private bool recoverTime = false;

    public void Awake()
    {
        playerAnim = GetComponentInChildren<Animator>();
        walkingSpeed = playerSO.walkingSpeed;
        sprintSpeed = playerSO.runningSpeed;
    }

    public void Update()
    {
        Run();
        if (isRunning)
        {
            playerSO.currentStamina -= playerSO.runningConsuming * 2 * Time.deltaTime;
        }
    }

    public void LateUpdate()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            playerAnim.SetBool("isRunningRight", true);
            playerAnim.SetBool("isRunningLeft", false);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            playerAnim.SetBool("isRunningRight", false);
            playerAnim.SetBool("isRunningLeft", true);
        }
        else
        {
            playerAnim.SetBool("isRunningRight", false);
            playerAnim.SetBool("isRunningLeft", false);
        }
    }

    public void Run()
    {
        if (playerSO.currentStamina < 0.1f)
        {
            recoverTime = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !recoverTime)
        {
            PlayerMovements.speed = sprintSpeed;
            playerAnim.SetBool("isRunning", true);
            isRunning = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && !recoverTime)
        {
            PlayerMovements.speed = walkingSpeed;
            playerAnim.SetBool("isRunning", false);
            isRunning = false;
        }
        else if (recoverTime)
        {
            if (playerSO.currentStamina < 30f)
            {
                PlayerMovements.speed = walkingSpeed;
                playerAnim.SetBool("isRunning", false);
                isRunning = false;
            }
            else
            {
                recoverTime = false;
            }
        }
    }
}
