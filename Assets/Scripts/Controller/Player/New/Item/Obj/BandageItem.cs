using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Item/Bandage")]
public class BandageItem : Item
{
    public HealingItemTpye healingItemTpye;
    public int Amount = 1;
    public int healling = 35;
}
