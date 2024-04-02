using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeCamera : MonoBehaviour
{
    public Transform Camera_Original;
    public Transform Camera_Aim;
    public GameObject Player;
    private CinemachineVirtualCamera AimVirtualCamera;
    
    public Transform Camera_BaseLookAt;
    public Transform Camera_EjectLookAt;
    public float EjectSpeed;

    public Transform cameraTransform;
    public float CamRotateSpeed;

    private void Start()
    {   
        AimVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    void Update()
    {
       
        //if(Input.GetMouseButton(1) && Input.GetMouseButtonDown(0))
        //{
        //    Quaternion TargetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        //    Camera_BaseLookAt.transform.rotation = Quaternion.Lerp(Camera_BaseLookAt.transform.rotation, TargetRotation, CamRotateSpeed * Time.deltaTime);

        //}

        if (Input.GetMouseButton(1))
        {
           
            AimVirtualCamera.Priority = 11;
           
        }
        else
        {
           
            AimVirtualCamera.Priority = 9;
           
        }

     

    }
}
