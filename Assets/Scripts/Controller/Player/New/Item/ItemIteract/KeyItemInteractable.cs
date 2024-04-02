using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemInteractable : InteractableObject
{
    [SerializeField] Item item;
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

        playerManager.playerInventoryManger.itemsInInventory.Add(item);
        Destroy(gameObject);
    }
}
