using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public InputManager inputManager;
    Animator animator;
    public AnimatorManager animatorManager;

    public PlayerUIManager playerUIManager;
    public PlayerCamera playerCamera;
    public PlayerMotionManager playerMotionManager;
    public PlayerEquipmentManager playerEquipmentManager;
    public PlayerInventoryManger playerInventoryManger;
    public PlayerStatManager playerStatManager;
    [SerializeField] CameraShake cameraShake;

    [Header("VFX")]
    public GameObject FireVFX;
    public Transform FireVFX_Pos;

    [Header("SFX")]
    public AudioSource DryFire;
    

    [Header("Player Flages")]
    public bool disableRootMotion;
    public bool isPreformingAction;
    public bool isPreformingQuickTurn;
    public bool isAiming;
    public bool canInteract;

    [Header("Status")]
    public bool isDead;
    public bool RegenHealth = false;

    [Header("Collider")]
    public SphereCollider sphereCollider;
    public float soundIntensity = 5f;

    private int count = 1;
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        animator = GetComponent<Animator>();
        animatorManager = GetComponent<AnimatorManager>();

        playerUIManager = FindObjectOfType<PlayerUIManager>();
        playerCamera = FindObjectOfType<PlayerCamera>();                
        playerMotionManager = GetComponent<PlayerMotionManager>();
        playerEquipmentManager = GetComponent<PlayerEquipmentManager>();        
        playerInventoryManger = GetComponent<PlayerInventoryManger>();
        playerStatManager = GetComponent<PlayerStatManager>();
        sphereCollider = GetComponent<SphereCollider>();
    }
    private void Update()
    {
        inputManager.HandleAllInput();

        disableRootMotion = animator.GetBool("disableRootMotion");
        isAiming = animator.GetBool("isAiming");
        isPreformingAction = animator.GetBool("isPreformingAction");
        isPreformingQuickTurn = animator.GetBool("isPreformingQuickTurn");
        animator.SetBool("isDead", isDead);
    }
    private void FixedUpdate()
    {
        playerMotionManager.HandleAllMotion();
        if (sphereCollider.radius > 1f)
        {
            sphereCollider.radius -= Time.deltaTime;
        }
    }
    private void LateUpdate()
    {
        playerCamera.HandleAllCameraMovement();
    }
    public void UseCurrentWeapon()
    {
        if (isPreformingAction)
        {
            return;
        }

        if (playerEquipmentManager.weapon.remainingAmmo > 0)
        {
            playerEquipmentManager.weapon.remainingAmmo = playerEquipmentManager.weapon.remainingAmmo - 1;
            playerUIManager.currentAmmoCountText.text = playerEquipmentManager.weapon.remainingAmmo.ToString();
            playerEquipmentManager.weaponAnimationManager.ShootWeapon(playerCamera);
            cameraShake.ScreenShake();
            //FireVFX.SetActive(true);
            GameObject fireVFX = Instantiate(FireVFX,FireVFX_Pos);
            
        }
        else
        {
            DryFire.Play();
            Debug.Log("Reload");
        }
        
    }
    public void UseMedpen()
    {
        foreach (Item item in playerInventoryManger.itemsInInventory)
        {
            if (item.itemName == "Medpen")
            {
                playerInventoryManger.itemsInInventory.Remove(item);
                playerStatManager.playerHealth += 60;
                break;
            }
        }      
    }
    public void UseBandage()
    {
        foreach (Item item in playerInventoryManger.itemsInInventory)
        {
            if (item.itemName == "Bandage")
            {

                playerInventoryManger.itemsInInventory.Remove(item);
                animatorManager.animator.Play("Player_Heal");
                playerStatManager.playerHealth += 30;
                RegenHealth = true;
                break;
            }
        }
    }
    internal void openInventoryInput()
    {
        count += 1;
        if (count%2 == 0)
        {
            inputManager.pauseMenu.openInventory = true;
            inputManager.pauseMenu.HpBar.value = playerStatManager.playerHealth / 100;
        }
        else
        {
            inputManager.pauseMenu.openInventory = false;
        }
    }
}
