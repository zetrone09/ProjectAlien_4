using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteracable : InteractableObject
{
    [Header("DoorAnimation")]
    [SerializeField] Animator dooranimator;

    [Header("LockDetails")]
    [SerializeField] bool isLocked;
    [SerializeField] bool requiresKey;
    [SerializeField] string keyID;
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }
    protected override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);
    }
    protected override void Interact(PlayerManager playerManager)
    {
        base.Interact(playerManager);

        if (isLocked)
        {
            if (requiresKey && isLocked)
            {
                foreach (Item item in player.playerInventoryManger.itemsInInventory)
                {
                    if (item.ItemID == keyID)
                    {
                        isLocked = false;
                        player.playerInventoryManger.itemsInInventory.Remove(item);
                        break;
                    }
                }
            }                       
        }
        if (!isLocked)
        {
            interactableImgage.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
