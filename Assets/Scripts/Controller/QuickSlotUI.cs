using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlotUI : MonoBehaviour
{
    public Image BandageIcon;
    public Image MedicPenIcon;

    public void UpdateQuickBandageSlotUI(Item item)
    {
        if (item != null)
        {
            BandageIcon.sprite = item.itemIcon;
            BandageIcon.enabled = true;
            
        }
        else
        {
            BandageIcon.sprite = null;
            BandageIcon.enabled = false;
        }

    }   
    public void UpdateQuickMedicPenSlotUI(Item item)
    { 
        if (item != null)
        {
            MedicPenIcon.sprite = item.itemIcon;
            MedicPenIcon.enabled = true;
        }
        else
        {
            MedicPenIcon.sprite = null;
            MedicPenIcon.enabled = false;
        }
    }
}
