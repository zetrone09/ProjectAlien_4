using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    protected PlayerManager player;
    [SerializeField]protected GameObject interactableImgage;
    protected Collider interactableCollider;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (player == null)
        {
            player = other.GetComponent<PlayerManager>();
        }
        if (player != null)
        {
            interactableImgage.SetActive(true);
            player.canInteract = true;
        }
    }
    protected virtual void OnTriggerStay(Collider other)
    {
        if (player == null)
        {
            player = other.GetComponent<PlayerManager>();
        }
        if (player != null)
        {
           

            if (player.inputManager.interactionInput)
            {
                Interact(player);
                player.canInteract = false;
                player.inputManager.interactionInput = false;

            }
            
        }    
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        if (player == null)
        {
            player = other.GetComponent<PlayerManager>();
        }
        if (player != null)
        {
            interactableImgage.SetActive(false);
            player.canInteract = false;
        }
    }
    protected virtual void Interact(PlayerManager playerManager)
    {
        Debug.Log("Interact");
    }
}
