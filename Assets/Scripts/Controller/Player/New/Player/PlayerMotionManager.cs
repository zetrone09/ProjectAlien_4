using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotionManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerManager playerManager;

    public Rigidbody playerRigibody;

    [Header("Camera Transform")]
    public Transform playerCamera;

    [Header("Movement Speed")]
    public float rotationSpeed = 3.5f;
    public float quickSpeed = 5f;

    [Header("Rotation Varaibles")]
    Quaternion targetRotation;
    Quaternion playerRotation;

    [Header("CheckGround")]
    public bool IsGrounded;
    public float rayCastHeightOffSet = 0.5f;
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRigibody = GetComponent<Rigidbody>();
        playerManager = GetComponent<PlayerManager>();
    }
    public void HandleAllMotion()
    {
        if (playerManager.isPreformingAction)
        {
            return;
        }
        HandleRotation();
        HandleFallig();
    }
    public void HandleRotation()
    {
        if (playerManager.isAiming)
        {
            targetRotation = Quaternion.Euler(0, playerCamera.eulerAngles.y, 0);
            playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = playerRotation;
        }
        else
        {
            targetRotation = Quaternion.Euler(0, playerCamera.eulerAngles.y, 0);
            playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (inputManager.verticalMovementInput != 0 || inputManager.horizontalMovementInput != 0)
            {
                transform.rotation = playerRotation;
            }
            if (playerManager.isPreformingQuickTurn)
            {
                playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, quickSpeed * Time.deltaTime);
                transform.rotation = playerRotation;
            }
        }
        
    }
    public void HandleFallig()
    {
        RaycastHit hit;
        Vector3 rayCastOrigin = transform.position;
        Vector3 targetPosition;
        rayCastOrigin.y += rayCastHeightOffSet;
        targetPosition = transform.position;

        if (Physics.SphereCast(rayCastOrigin,0.2f,-Vector3.up,out hit))
        {
            Vector3 rayCastHitPoint = hit.point;
            targetPosition.y = rayCastHitPoint.y;
            IsGrounded = true;
        }
        else
        {
            IsGrounded = true;
        }

        if (IsGrounded)
        {
            if (playerManager.inputManager.horizontalMovementInput > 0 || playerManager.inputManager.verticalMovementInput > 0)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime / 0.1f);
            }
            else
            {
                transform.position = targetPosition;
            }
        }
    }
}
