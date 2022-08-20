using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    [SerializeField]
    private Transform playerRoot;
    [SerializeField]
    private Transform playerBody;
    [SerializeField]
    private Transform lookRoot;
    [SerializeField]
    private bool invert;
    [SerializeField]
    private Player playerSO;

    [SerializeField]
    private float sensibility = 2f;
    [SerializeField]
    private float rollAngle = 0.3f;
    [SerializeField]
    private float rollSpeed = 3f;

    [SerializeField]
    private Vector2 default_look_limits = new Vector2(-20f, 50f);
    private Vector2 lookAngles;
    private Vector2 currentMouseLook;
    private float currentRollAngle;
    private float zero = 0f;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void FixedUpdate()
    {
        LockAndUnlockCursor();
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            LookAround();
        }
    }

    public void LateUpdate()
    {
        if (!PlayerMovements.playerIsMoving && PlayerMovements.playerStoppedMoving)
        {
            zero = lookAngles.y;
            PlayerMovements.playerStoppedMoving = false;
        }

        if (!PlayerMovements.playerIsMoving)
        {
            playerBody.Rotate(new Vector3(0f, -lookAngles.y + zero, 0f));
        }
    }

    public void LockAndUnlockCursor()
    {
        if (Input.GetKey(KeyCode.Escape) && Cursor.lockState == CursorLockMode.Locked || playerSO.isDead)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKey(KeyCode.Escape) && Cursor.lockState == CursorLockMode.None && !playerSO.isDead)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void LookAround()
    {
        if (!playerSO.isDead)
        {
            currentMouseLook = new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));

            lookAngles.x += currentMouseLook.x * sensibility * (invert ? 1f : -1f);
            lookAngles.y += currentMouseLook.y * sensibility;

            lookAngles.x = Mathf.Clamp(lookAngles.x, default_look_limits.x, default_look_limits.y);
            currentRollAngle = Mathf.Lerp(currentRollAngle, Input.GetAxis("Mouse X") * rollAngle, Time.deltaTime * rollSpeed);

            lookRoot.localRotation = Quaternion.Euler(lookAngles.x, 0f, currentRollAngle);
            playerRoot.localRotation = Quaternion.Euler(0f, lookAngles.y, 0f);
        }
    }
}
