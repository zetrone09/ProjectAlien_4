using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] CinemachineImpulseSource screenShake;
    [SerializeField] float powerAmount;
    public void ScreenShake()
    {
        screenShake.GenerateImpulse(powerAmount);
    }
}
