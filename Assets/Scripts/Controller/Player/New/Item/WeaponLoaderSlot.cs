using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLoaderSlot : MonoBehaviour
{
    public GameObject currentWeaponModel;
    public void LoadWeaponModel(WeaponItem weapon) 
    {
        UnLoadAndDestroyWeapon();
        if (weapon == null)
        {
            return;
        }
        GameObject weaponModel = Instantiate(weapon.itemModel, transform);
        weaponModel.transform.localPosition = Vector3.zero;
        weaponModel.transform.localRotation = Quaternion.identity;
        weaponModel.transform.localScale = Vector3.one;
        currentWeaponModel = weaponModel;
    }
    private void UnLoadAndDestroyWeapon()
    {
        if (currentWeaponModel != null)
        {
            Destroy(currentWeaponModel);
        }
    }
}
