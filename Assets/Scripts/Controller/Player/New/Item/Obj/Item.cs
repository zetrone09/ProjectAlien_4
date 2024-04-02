using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : ScriptableObject
{
    [Header("Item information")]
    public string itemName;
    public GameObject itemModel;
    public Sprite itemIcon;
    public string ItemID;
    public int ammoRemaining;
}
