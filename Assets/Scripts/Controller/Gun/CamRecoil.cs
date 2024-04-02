using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRecoil : MonoBehaviour
{
    private Vector3 currentRotation;
    private Vector3 targetRotation;

    [SerializeField] private float recoilX;
    [SerializeField] private float recoilY;

    [SerializeField] private float snap;
    [SerializeField] private float returnSpeed;

    void Update()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, snap * Time.fixedDeltaTime);
        transform.rotation = Quaternion.Euler(currentRotation);
    }

    public void Recoil()
    {
        targetRotation -= new Vector3(recoilX, Random.Range(-recoilY, recoilY), 0f);
    }
}
