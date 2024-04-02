using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    InputManager inputManager;
    PlayerManager playerManager;

    public Transform cameraPivot;
    public Camera cameraObject;

    [Header("Camera Follow Target")]
    public GameObject player;
    public Transform aimedCameraPosition;

  

    Vector3 cameraFollowVelocity = Vector3.zero;
    Vector3 targetPosition;
    Vector3 cameraRotation;   
    Quaternion targetRotation;

    [Header("Camera Speeds")]
    public float cameraSmoothTime = 0.2f;
    public float aimCameraSmoothTime = 3f;

    float lookVertical;
    float lookHorizontal;
    float maximumPivotAngle = 85;
    float minimumPivotAngle = -60;
    private void Awake()
    {
        inputManager = player.GetComponent<InputManager>();
        playerManager = player.GetComponent<PlayerManager>();
        
    }
    public void HandleAllCameraMovement()
    {
        FollowPlayer();
       // RotationCamera();        
    }
    private void FollowPlayer()
    {
        if (playerManager.isAiming)
        {
            targetPosition = Vector3.SmoothDamp(transform.position, aimedCameraPosition.transform.position, ref cameraFollowVelocity, aimCameraSmoothTime * Time.deltaTime);
            transform.position = targetPosition;
        }
        else
        {
            targetPosition = Vector3.SmoothDamp(transform.position, player.transform.position, ref cameraFollowVelocity, cameraSmoothTime * Time.deltaTime);
            transform.position = targetPosition;
        }       
    }
    //private void RotationCamera()
    //{
    //    if (playerManager.isAiming)
    //    {
    //        cameraPivot.localRotation = Quaternion.Euler(0, 0, 0);

    //        lookVertical = lookVertical + (inputManager.horizontalCameraInput);
    //        lookHorizontal = lookHorizontal - (inputManager.verticalCameraInput);
    //        lookHorizontal = Mathf.Clamp(lookHorizontal, minimumPivotAngle, maximumPivotAngle);

    //        cameraRotation = Vector3.zero;
    //        cameraRotation.y = lookVertical;
    //        targetRotation = Quaternion.Euler(cameraRotation);
    //        targetRotation = Quaternion.Slerp(transform.rotation, targetRotation, aimCameraSmoothTime);
    //        transform.rotation = targetRotation;

    //        cameraRotation = Vector3.zero;
    //        cameraRotation.x = lookHorizontal;
    //        targetRotation = Quaternion.Euler(cameraRotation);
    //        targetRotation = Quaternion.Slerp(cameraPivot.localRotation, targetRotation, aimCameraSmoothTime);
    //        cameraObject.transform.localRotation = targetRotation;
    //    }
    //    else
    //    {
    //        cameraObject.transform.localRotation = Quaternion.Euler(0, 0, 0);

    //        lookVertical = lookVertical + (inputManager.horizontalCameraInput);
    //        lookHorizontal = lookHorizontal - (inputManager.verticalCameraInput);
    //        lookHorizontal = Mathf.Clamp(lookHorizontal, 0, 0);

    //        cameraRotation = Vector3.zero;
    //        cameraRotation.y = lookVertical;
    //        targetRotation = Quaternion.Euler(cameraRotation);
    //        targetRotation = Quaternion.Slerp(transform.rotation, targetRotation, cameraSmoothTime);
    //        transform.rotation = targetRotation;

    //        if (inputManager.quickTurnInput)
    //        {
    //            inputManager.quickTurnInput = false;
    //            lookVertical = lookVertical + 180;
    //            cameraRotation.y = cameraRotation.y + 180;
    //            transform.rotation = targetRotation;
    //        }

    //        cameraRotation = Vector3.zero;
    //        cameraRotation.x = lookHorizontal;
    //        targetRotation = Quaternion.Euler(cameraRotation);
    //        targetRotation = Quaternion.Slerp(cameraPivot.localRotation, targetRotation, cameraSmoothTime);
    //        cameraPivot.localRotation = targetRotation;
    //    }
    //}




}
