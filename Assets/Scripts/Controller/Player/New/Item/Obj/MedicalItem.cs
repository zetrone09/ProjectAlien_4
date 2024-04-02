using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Medicpen")]
public class MedicalItem : Item
{
    public HealingItemTpye healingItemTpye;
    public int Amount = 1;
    public int healling = 50;
    
}
