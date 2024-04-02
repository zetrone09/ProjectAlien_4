using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentManager : MonoBehaviour
{
    PlayerManager playerManager;
    WeaponLoaderSlot weaponLoaderSlot;

    [Header("Current Equipment")]
    public WeaponItem weapon;
    public WeaponAnimationManager weaponAnimationManager;

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        LoadWeaponLoaderSlot();
    }
    private void Start()
    {
        LoadCurrentWeapon();
    }
    private void LoadWeaponLoaderSlot()
    {
        //back
        //hip
        weaponLoaderSlot = GetComponentInChildren<WeaponLoaderSlot>();
    }
    private void LoadCurrentWeapon()
    {
        weaponLoaderSlot.LoadWeaponModel(weapon);
        playerManager.animatorManager.animator.runtimeAnimatorController = weapon.weaponAnimator;
        weaponAnimationManager = weaponLoaderSlot.currentWeaponModel.GetComponentInChildren<WeaponAnimationManager>();
        playerManager.playerUIManager.currentAmmoCountText.text = weapon.remainingAmmo.ToString();

        if (playerManager.playerInventoryManger.currentAmmoInInventory != null)
        {
            if (playerManager.playerInventoryManger.currentAmmoInInventory.ammoType == weapon.ammoType)
            {
                playerManager.playerUIManager.inventoryAmmoCountText.text = playerManager.playerInventoryManger.
                    currentAmmoInInventory.ammoRemaining.ToString();
            }
        }      
    }
}
