using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManger : MonoBehaviour
{
    public List<Item> itemsInInventory = new List<Item>();

    QuickSlotUI quickSlotUI;
    SlotInventoryUI slotInventoryUI;

    public AmmoItem currentAmmoInInventory;

    private void Awake()
    {
        quickSlotUI = FindObjectOfType<QuickSlotUI>();
        slotInventoryUI = FindObjectOfType<SlotInventoryUI>();
    }
    public void Update()
    {
        LoadItemOnInventorySlot1();
        LoadItemOnInventorySlot2();
        LoadItemOnInventorySlot3();
        LoadItemOnInventorySlot4();
        LoadItemOnInventorySlot5();
        LoadItemOnInventorySlot6();
        LoadItemOnBandageSlot();
        LoadItemOnMedPenSlot();

        Debug.Log("Invento == " + itemsInInventory.Count);
        
    }

    public void LoadAmmoInInventory()
    {
        if (itemsInInventory.Count != 0)
        {
            foreach (Item item in itemsInInventory)
            {
                if (item.ItemID == currentAmmoInInventory.ItemID)
                {
                    if (currentAmmoInInventory.ammoRemaining == 0 && currentAmmoInInventory.ammoRemaining < 7)
                    {                      
                        currentAmmoInInventory.ammoRemaining += item.ammoRemaining;
                        itemsInInventory.Remove(item);
                        break;
                    }
                }
                //else if (item.ItemID != currentAmmoInInventory.ItemID)
                //{
                //    break;
                //}
            }
        }
       
    }

    public void LoadItemOnInventorySlot1()
    {
        if (itemsInInventory.Count > 0)
        {
            if (itemsInInventory[0] != null)
            {
                slotInventoryUI.UpdateInventorySlotUI1(itemsInInventory[0]);
            }
            else
            {
                slotInventoryUI.UpdateInventorySlotUI1(null);
            }
        }
        else
        {
            slotInventoryUI.UpdateInventorySlotUI1(null);
        }
    }
    public void LoadItemOnInventorySlot2()
    {
        if (itemsInInventory.Count > 1)
        {
            if (itemsInInventory[1] != null)
            {
                slotInventoryUI.UpdateInventorySlotUI2(itemsInInventory[1]);
            }
            else
            {
                slotInventoryUI.UpdateInventorySlotUI2(null);
            }
        }
        else
        {
            slotInventoryUI.UpdateInventorySlotUI2(null);
        }
    }              
    public void LoadItemOnInventorySlot3()
    {
        if (itemsInInventory.Count > 2)
        {
            if (itemsInInventory[2] != null)
            {
                slotInventoryUI.UpdateInventorySlotUI3(itemsInInventory[2]);
            }
            else
            {
                slotInventoryUI.UpdateInventorySlotUI3(null);
            }
        }
        else
        {
            slotInventoryUI.UpdateInventorySlotUI3(null);
        }
    }
    public void LoadItemOnInventorySlot4()
    {
        if (itemsInInventory.Count > 3)
        {
            if (itemsInInventory[3] != null)
            {
                slotInventoryUI.UpdateInventorySlotUI4(itemsInInventory[3]);
            }
            else
            {
                slotInventoryUI.UpdateInventorySlotUI4(null);
            }
        }
        else
        {
            slotInventoryUI.UpdateInventorySlotUI4(null);
        }
    }
    public void LoadItemOnInventorySlot5()
    {
        if (itemsInInventory.Count > 4)
        {
            if (itemsInInventory[4] != null)
            {
                slotInventoryUI.UpdateInventorySlotUI5(itemsInInventory[4]);
            }
            else
            {
                slotInventoryUI.UpdateInventorySlotUI5(null);
            }
        }
        else
        {
            slotInventoryUI.UpdateInventorySlotUI5(null);
        }
    }
    public void LoadItemOnInventorySlot6()
    {
        if (itemsInInventory.Count > 5)
        {
            if (itemsInInventory[5] != null)
            {
                slotInventoryUI.UpdateInventorySlotUI6(itemsInInventory[5]);
            }
            else
            {
                slotInventoryUI.UpdateInventorySlotUI6(null);
            }
        }
        else
        {
            slotInventoryUI.UpdateInventorySlotUI6(null);
        }
    }
    public void LoadItemOnBandageSlot()
    {
        if (itemsInInventory.Count != 0)
        {
            foreach (Item item in itemsInInventory)
            {
                if (item.ItemID == "B-01")
                {
                    quickSlotUI.UpdateQuickBandageSlotUI(item);
                    Debug.Log("ComeIn_________________________");
                    //break;
                }
                else if (item.ItemID != "B-01")
                {
                    quickSlotUI.UpdateQuickBandageSlotUI(null);
                    Debug.Log("ComeOut_________________________");
                    //break;
                }
            }
        }
        else
        {
            quickSlotUI.UpdateQuickBandageSlotUI(null);
        }
    }
    public void LoadItemOnMedPenSlot()
    {
        if (itemsInInventory.Count != 0)
        {
            foreach (Item item in itemsInInventory)
            {
                if (item.ItemID == "M-01")
                {
                    quickSlotUI.UpdateQuickMedicPenSlotUI(item);
                    break;
                }

                else if (item.ItemID != "M-01")
                {
                    quickSlotUI.UpdateQuickMedicPenSlotUI(null);
                    break;
                }
            }
        }
        else
        {
            quickSlotUI.UpdateQuickMedicPenSlotUI(null);
        }
    }
}
