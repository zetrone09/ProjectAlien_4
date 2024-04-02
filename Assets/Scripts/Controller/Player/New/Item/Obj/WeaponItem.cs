using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/WeaponItem")]
public class WeaponItem : Item
{
    [Header("Weapon Animation")]
    public AnimatorOverrideController weaponAnimator;

    [Header("Weapon Damage")]
    public int damage = 25;

    [Header("Ammo")]
    public int remainingAmmo = 4;
    public int maximumAmmo = 12;
    public AmmoType ammoType;

   
}
