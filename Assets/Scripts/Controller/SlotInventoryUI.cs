using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotInventoryUI : MonoBehaviour
{
    public Image SlotIcon1;
    public Image SlotIcon2;
    public Image SlotIcon3;
    public Image SlotIcon4;
    public Image SlotIcon5;
    public Image SlotIcon6;

    public void UpdateInventorySlotUI1(Item item)
    {
        if (item != null)
        {
            SlotIcon1.sprite = item.itemIcon;
            SlotIcon1.enabled = true;
        }
        else
        {
            SlotIcon1.sprite = null;
            SlotIcon1.enabled = false;
        }
    }
    public void UpdateInventorySlotUI2(Item item)
    {
        if (item != null)
        {
            SlotIcon2.sprite = item.itemIcon;
            SlotIcon2.enabled = true;
        }
        else
        {
            SlotIcon2.sprite = null;
            SlotIcon2.enabled = false;
        }
    }
    public void UpdateInventorySlotUI3(Item item)
    {
        if (item != null)
        {
            SlotIcon3.sprite = item.itemIcon;
            SlotIcon3.enabled = true;
        }
        else
        {
            SlotIcon3.sprite = null;
            SlotIcon3.enabled = false;
        }
    }
    public void UpdateInventorySlotUI4(Item item)
    {
        if (item != null)
        {
            SlotIcon4.sprite = item.itemIcon;
            SlotIcon4.enabled = true;
        }
        else
        {
            SlotIcon4.sprite = null;
            SlotIcon4.enabled = false;
        }
    }
    public void UpdateInventorySlotUI5(Item item)
    {
        if (item != null)
        {
            SlotIcon5.sprite = item.itemIcon;
            SlotIcon5.enabled = true;
        }
        else
        {
            SlotIcon5.sprite = null;
            SlotIcon5.enabled = false;
        }
    }
    public void UpdateInventorySlotUI6(Item item)
    {
        if (item != null)
        {
            SlotIcon6.sprite = item.itemIcon;
            SlotIcon6.enabled = true;
        }
        else
        {
            SlotIcon6.sprite = null;
            SlotIcon6.enabled = false;
        }
    }
}
