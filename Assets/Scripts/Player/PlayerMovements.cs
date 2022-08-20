using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public Player playerSO;
    private CharacterController charController;
    private Animator playerAnim;
    [SerializeField]
    private Transform playerBody;

    private Vector3 moveDirections;
    public static float speed;
    private float gravity = 20f;
    private float jumpForce;
    private float verticalVelocity;
    public static bool playerIsMoving = false;
    public static bool playerStoppedMoving = false;

    public void Awake()
    {
        charController = GetComponent<CharacterController>();
        playerAnim = GetComponentInChildren<Animator>();

        speed = playerSO.walkingSpeed;
        jumpForce = playerSO.jumpingForce;
    }

    public void Update()
    {
        MovePlayer();
        if (playerSO.currentStamina > playerSO.jumpingConsuming)
        {
            PlayerJump();
        }
    }

    public void LateUpdate()
    {
        // the code below is to check if it has to be the side walk animation

        if (Input.GetAxis("Horizontal") > 0)
        {
            playerAnim.SetBool("isWalkingRight", true);
            playerAnim.SetBool("isWalkingLeft", false);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            playerAnim.SetBool("isWalkingRight", false);
            playerAnim.SetBool("isWalkingLeft", true);
        }
        else
        {
            playerAnim.SetBool("isWalkingRight", false);
            playerAnim.SetBool("isWalkingLeft", false);
        }
    }

    public void MovePlayer()
    {
        if (!playerSO.isDead)
        {
            moveDirections = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            // the code below is to run the walking animation

            if (moveDirections.x != 0 || moveDirections.y != 0 || moveDirections.z != 0)
            {
                playerIsMoving = true;
                playerAnim.SetBool("isWalking", true);
            }
            else if (playerIsMoving)
            {
                playerIsMoving = false;
                playerStoppedMoving = true;
                playerAnim.SetBool("isWalkingRight", false);
                playerAnim.SetBool("isWalkingLeft", false);
            }
            else
            {
                playerAnim.SetBool("isWalking", false);
            }

            moveDirections = transform.TransformDirection(moveDirections * speed * Time.deltaTime);
        }
        ApplyGravity();
        charController.Move(moveDirections);

        playerBody.position = transform.position;
        playerBody.rotation = transform.rotation;
    }

    public void ApplyGravity()
    {
        verticalVelocity -= gravity * Time.deltaTime;
        moveDirections.y = verticalVelocity * Time.deltaTime;
    }

    public void PlayerJump()
    {
        if (charController.isGrounded && Input.GetKey(KeyCode.Space))
        {
            verticalVelocity = jumpForce;
            playerAnim.SetBool("isJumping", true);
            playerSO.currentStamina -= playerSO.jumpingConsuming;
        }
        else
        {
            playerAnim.SetBool("isJumping", false);
        }
    }
}