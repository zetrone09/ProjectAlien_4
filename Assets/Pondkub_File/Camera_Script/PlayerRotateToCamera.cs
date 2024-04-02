using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotateToCamera : MonoBehaviour
{
    private Transform cameraTransform;
    public GameObject MainCam;
    public GameObject Player;
    public float PlayerRotateSpeed;
    void Start()
    {
        cameraTransform = MainCam.transform;
    }

    
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Quaternion TargetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
            Player.transform.rotation = Quaternion.Lerp(transform.rotation, TargetRotation, PlayerRotateSpeed * Time.deltaTime);
        }
        
    }
}
