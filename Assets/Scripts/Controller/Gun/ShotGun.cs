using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ShotGun : MonoBehaviour
{
    public GameObject shotGun;
    public Transform barral;
    public TextMeshProUGUI Bullet;
    public TextMeshProUGUI Magazine;
    public Transform bulletParent;
    public GameObject bulletPrefab;

    private Transform camTransform;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private CamRecoil camRecoil;
    private InputAction aimAction;
    private InputAction fireAction;
    private InputAction reloadAction;

    [Header("Ammo")]
    private int maxMagazine = 2;
    private int emptyMagazine = 0;
    private int bulletPerMagazine = 2;
    private int bulletInMagazine = 2;
    private float MissDistance = 0.2f;

    private void Awake()
    {
        aimAction = playerInput.actions["Aim"];
        fireAction = playerInput.actions["Fire"];
        reloadAction = playerInput.actions["Reload"];
        Magazine.text = " / " + maxMagazine;
        Bullet.text = "" + bulletInMagazine;
        camTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (aimAction.inProgress )
        {
            if (fireAction.triggered)
            {
                if (bulletInMagazine != emptyMagazine)
                {
                    bulletInMagazine--;
                    Fire();
                    camRecoil.Recoil();
                }
                else { Debug.Log("emptyMagazine"); }
            }
            else if(reloadAction.triggered)
            {              
                 Reload();             
            }           
        }
        if (reloadAction.triggered)
        {
            Reload();
        }
        Magazine.text = "" + maxMagazine;
        Bullet.text = "" + bulletInMagazine;
    }
    private void Fire()
    {
        RaycastHit hit;
        GameObject bullet = GameObject.Instantiate(bulletPrefab, barral.position, Quaternion.identity, bulletParent);
        Bullet BulletController = bullet.GetComponent<Bullet>();
        if (Physics.Raycast(camTransform.position,camTransform.forward,out hit, Mathf.Infinity))
        {          
            BulletController.target = hit.point;
            BulletController.hit = true;
        }
        else
        {           
            BulletController.target = camTransform.position + camTransform.forward * MissDistance;
            BulletController.hit = false;
        }
    }

    private void Reload()
    {
        if (maxMagazine > emptyMagazine)
        {

            for (int i = maxMagazine; i > emptyMagazine; i--)
            {
                if (bulletInMagazine < bulletPerMagazine)
                {
                    maxMagazine--;
                    bulletInMagazine++;
                }
            }
        }
        if (maxMagazine <= emptyMagazine)
        {
            maxMagazine = emptyMagazine;
        }
    }

    public int getBullet(int bullet)
    {
        maxMagazine += bullet;
        Magazine.text = "" + maxMagazine;
        Bullet.text = "" + bulletInMagazine;
        return maxMagazine;
    }
}
