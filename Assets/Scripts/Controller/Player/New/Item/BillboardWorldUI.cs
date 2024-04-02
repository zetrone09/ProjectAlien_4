using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardWorldUI : MonoBehaviour
{
    Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }
    private void LateUpdate()
    {
        if (mainCamera != null)
        {
            transform.LookAt(mainCamera.transform.position + mainCamera.transform.forward);
        }
    }
}
