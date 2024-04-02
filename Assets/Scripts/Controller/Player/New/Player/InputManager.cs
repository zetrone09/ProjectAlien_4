using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    PlayerControl playerControl;
    AnimatorManager animatorManager;
    Animator animator;
    PlayerManager playerManager;
    PlayerUIManager playerUIManager;
    public PauseMenu pauseMenu;

    [Header("Player Movement")]
    public float horizontalMovementInput;
    public float verticalMovementInput;
    private Vector2 movementInput;

    [Header("Camera Rotation")]
    public float horizontalCameraInput;
    public float verticalCameraInput;
    private Vector2 cameraInput;

    [Header("Button Inputs")]
    public bool runInput;
    public bool quickTurnInput;
    public bool aimingInput;
    public bool shootInput;
    public bool reloadInput;
    public bool interactionInput;
    public bool pauseInput;
    public bool useBandageInput;
    public bool useMedicInput;
    public bool openInventoryInput;

    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        animator = GetComponent<Animator>();
        playerManager = GetComponent<PlayerManager>();
        playerUIManager = FindObjectOfType<PlayerUIManager>();
        pauseMenu = FindObjectOfType<PauseMenu>();
        
    }
    private void OnEnable()
    {
        if (playerControl == null)
        {
            playerControl = new PlayerControl();

            playerControl.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControl.PlayerMovement.Look.performed += i => cameraInput = i.ReadValue<Vector2>();
            playerControl.PlayerMovement.Run.performed += i => runInput = true;
            playerControl.PlayerMovement.Run.canceled += i => runInput = false;
            //playerControl.PlayerMovement.QuickTurn.performed += i => quickTurnInput = true;
            playerControl.PlayerMovement.Pause.started += i => pauseInput = true;
            playerControl.PlayerActions.Aim.performed += i => aimingInput = true;
            playerControl.PlayerActions.Aim.canceled += i => aimingInput = false;
            playerControl.PlayerActions.Shoot.performed += i => shootInput = true;
            playerControl.PlayerActions.Shoot.canceled += i => shootInput = false;
            playerControl.PlayerActions.Reload.performed += i => reloadInput = true;
            playerControl.PlayerActions.Interact.started += i => interactionInput = true;
            playerControl.PlayerActions.Interact.canceled += i => interactionInput = false;
            playerControl.PlayerActions.UseBandage.started += i => useBandageInput = true;
            playerControl.PlayerActions.UseBandage.canceled += i => useBandageInput = false;
            //playerControl.PlayerActions.UseMedicpen.started += i => useMedicInput = true;
            playerControl.PlayerActions.Inventory.started += i => openInventoryInput = true;
        }

        playerControl.Enable();
    }
    private void OnDisable()
    {
        playerControl.Disable();
    }
    public void HandleAllInput()
    {
        HandleMovementInput();
        HandleCameraInput();
        HandleQuickTurnInput();
        HandleAimingInput();
        HandleShootingInput();
        HandleReloadInput();
        HandleInteractionInput();
        HandlePauseInput();
        HandleUseBandageInput();
        HandleUseMedicpenInput();
        HandleOpenInventoryInput();
    }
    private void HandleMovementInput()
    {
        horizontalMovementInput = movementInput.x;
        verticalMovementInput = movementInput.y;
        animatorManager.HandleAnimatorValue(horizontalMovementInput, verticalMovementInput, runInput);
    }
    private void HandleCameraInput()
    {
        horizontalCameraInput = cameraInput.x * 7 * Time.deltaTime;
        verticalCameraInput = cameraInput.y * 7 * Time.deltaTime;
    }
    private void HandleQuickTurnInput()
    {
        if (playerManager.isPreformingAction)
        {
            return;
        }
        if (quickTurnInput)
        {
            animator.SetBool("isPreformingQuickTurn", true);
            animatorManager.PlayAnimation("player_QuickTurn_01", true);
        }
    }
    private void HandleAimingInput()
    {
        //if (verticalMovementInput != 0 || horizontalMovementInput != 0)
        //{
        //    aimingInput = false;
        //    animator.SetBool("isAiming", false);
        //    playerUIManager.crossHair.SetActive(false);
        //    return;
        //}

        if (aimingInput)
        {
            //animatorManager.PlayAnimation("Player_Aim", true);
            animator.SetBool("isAiming", true);
            playerUIManager.crossHair.SetActive(true);
            
        }
        else
        {
            animator.SetBool("isAiming", false);
            playerUIManager.crossHair.SetActive(false);
        }
        animatorManager.UpdateAimContraints();
    }
    private void HandleShootingInput()
    {
        if (aimingInput && shootInput)
        {           
            shootInput = false;

            playerManager.UseCurrentWeapon();
            animatorManager.PlayAnimation("FireGun", true);
        }
       
    }
    private void HandleReloadInput()
    {
        if (playerManager.isPreformingAction)
        {
            return;
        }
        if (reloadInput)
        {
            
            playerManager.playerInventoryManger.LoadAmmoInInventory();
            reloadInput = false;
            if (playerManager.playerEquipmentManager.weapon.remainingAmmo == playerManager.playerEquipmentManager.weapon.maximumAmmo)
            {
                return;
            }
            if (playerManager.playerInventoryManger.currentAmmoInInventory != null)
            {
                
                if (playerManager.playerInventoryManger.currentAmmoInInventory.ammoType == playerManager.playerEquipmentManager.weapon.ammoType)
                {
                    
                    if (playerManager.playerInventoryManger.currentAmmoInInventory.ammoRemaining == 0)
                    {
                        return;
                    }

                    int ammoToReLoad;
                    ammoToReLoad = playerManager.playerEquipmentManager.weapon.maximumAmmo - playerManager.playerEquipmentManager.weapon.remainingAmmo;

                    if (playerManager.playerInventoryManger.currentAmmoInInventory.ammoRemaining >= ammoToReLoad)
                    {
                        playerManager.animatorManager.animator.Play("Player_Reload");
                        playerManager.playerEquipmentManager.weapon.remainingAmmo = playerManager.playerEquipmentManager.weapon.remainingAmmo + ammoToReLoad;

                        playerManager.playerInventoryManger.currentAmmoInInventory.ammoRemaining =
                            playerManager.playerInventoryManger.currentAmmoInInventory.ammoRemaining - ammoToReLoad;
                    }
                    else
                    {
                        playerManager.playerEquipmentManager.weapon.remainingAmmo = playerManager.playerInventoryManger.currentAmmoInInventory.ammoRemaining;
                        playerManager.playerInventoryManger.currentAmmoInInventory.ammoRemaining = 0;
                    }
                    playerManager.playerUIManager.currentAmmoCountText.text = playerManager.playerEquipmentManager.weapon.remainingAmmo.ToString();
                    playerManager.playerUIManager.inventoryAmmoCountText.text = playerManager.playerInventoryManger.currentAmmoInInventory.ammoRemaining.ToString();
                }
            }
        }
    }
    private void HandleInteractionInput()
    {
        if (interactionInput)
        {
            if (!playerManager.canInteract)
            {
                interactionInput = false;
            }
        }
    }
    private void HandlePauseInput()
    {
        if (pauseInput)
        {   
            pauseMenu.isPaused = true;
            pauseInput = false;
            
        }

        if (pauseMenu.isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

    }
    private void HandleUseBandageInput()
    {
        if (useBandageInput)
        {
            if (!playerManager.canInteract)
            {
                useBandageInput = false;
                
                playerManager.UseBandage();
            }
        }        
    }
    private void HandleUseMedicpenInput()
    {
        if (useMedicInput)
        {
            if (!playerManager.canInteract)
            {
                useMedicInput = false;
                playerManager.UseMedpen();             
            }
        }
    }
    private void HandleOpenInventoryInput()
    {       
        if (openInventoryInput)
        {
            openInventoryInput = false;
            playerManager.openInventoryInput();
        }
    }
}
