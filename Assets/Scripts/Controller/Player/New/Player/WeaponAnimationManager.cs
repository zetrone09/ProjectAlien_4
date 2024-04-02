using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WeaponAnimationManager : MonoBehaviour
{
    PlayerManager player;
    Animator weaponAnimator;
    CamRecoil camRecoil;
   
    [Header("VFX")]
    public GameObject bloodVfx;
    public Transform bloodPosition;

    [Header("Weapon FX")]
    public GameObject weaponMuzzlefFlashFX;
    public GameObject weaponBulletCaseFX;

    [Header("Weapon FX Transforms")]
    public Transform weaponMuzzlefFlashTransform;
    public Transform weaponBulletCaseTransform;

    [Header("Weapon Bullet Range")]
    public float bulletRange = 1000f;

    [Header("Weapon SFX")]
    public AudioClip weaponShootSFXClip;
    public AudioSource weaponShootSFXSource;
    public SphereCollider sphereCollider;
    public float soundIntensity = 5f;

    [Header("Shootable Layer")]
    public LayerMask shootAbleLayers;

    [Header("Barral Transform")]
    public Transform barral;

    void Awake()
    {
        camRecoil = FindObjectOfType<CamRecoil>();
        weaponAnimator = GetComponentInChildren<Animator>();
        player = GetComponentInParent<PlayerManager>();
        sphereCollider = player.sphereCollider;
        
        
    }

    public void ShootWeapon(PlayerCamera playerCamera)
    {
        //GameObject muzzleFlash = Instantiate(weaponMuzzlefFlashFX, weaponMuzzlefFlashTransform);
        //muzzleFlash.transform.parent = null;

        //GameObject bulletCase = Instantiate(weaponBulletCaseFX, weaponBulletCaseTransform);
        //bulletCase.transform.parent = null;

        StartCoroutine("soundShoot");

        //var ray = new Ray(this.transform.position,this.transform.forward);
        RaycastHit hit;
        

        Debug.DrawRay(playerCamera.cameraObject.transform.position, playerCamera.cameraObject.transform.forward * bulletRange, Color.green, 10);
        if (Physics.Raycast(playerCamera.cameraObject.transform.position, playerCamera.cameraObject.transform.forward, out hit, bulletRange, shootAbleLayers))
        {
            Instantiate(bloodVfx, hit.point,Quaternion.LookRotation(hit.normal));
         

            Debug.Log(hit.collider.gameObject.layer);          
            GenralTypeEffectManager genralType = hit.collider.gameObject.GetComponentInParent<GenralTypeEffectManager>();

            
            
            if (genralType != null)
            {
                if (hit.collider.gameObject.layer == 8)
                {
                    genralType.DamageHead(player.playerEquipmentManager.weapon.damage);
                }
                else if (hit.collider.gameObject.layer == 9)
                {
                    genralType.DamageTorse(player.playerEquipmentManager.weapon.damage);
                }
                else if (hit.collider.gameObject.layer == 10)
                {
                    genralType.DamageLeftArm(player.playerEquipmentManager.weapon.damage);
                }
                else if (hit.collider.gameObject.layer == 11)
                {
                    genralType.DamageRightArm(player.playerEquipmentManager.weapon.damage);
                }
                else if (hit.collider.gameObject.layer == 12)
                {
                    genralType.DamageLeftLeg(player.playerEquipmentManager.weapon.damage);
                }
                else if (hit.collider.gameObject.layer == 13)
                {
                    genralType.DamageRightLeg(player.playerEquipmentManager.weapon.damage);
                }
            }
        }
    }

    IEnumerator soundShoot()
    {
        weaponShootSFXSource.PlayOneShot(weaponShootSFXClip);
        yield return new WaitForSeconds(0.01f);
        sphereCollider.radius = soundIntensity;
        yield return new WaitForSeconds(0.01f);
    }
}
