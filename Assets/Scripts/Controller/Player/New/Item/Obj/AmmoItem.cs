using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/AmmoItem")]
public class AmmoItem : Item
{
    public AmmoType ammoType;
    public int ammoCapacity = 50;
}
