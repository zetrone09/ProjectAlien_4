using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIManager : MonoBehaviour
{
    PlayerManager player;

    [Header("Crosshair")]
    public GameObject crossHair;

    [Header("Ammo")]
    public TextMeshProUGUI currentAmmoCountText;
    public TextMeshProUGUI inventoryAmmoCountText;

    [Header("Damage Screen")]
    [SerializeField] private Image bloodScreen;
    [SerializeField] private Image blackScreen;
    private void Awake()
    {
        player = FindObjectOfType<PlayerManager>();
    }
    private void Update()
    {
        Color bloodAlpha = bloodScreen.color;
        bloodAlpha.a = 1 - (player.playerStatManager.playerHealth / 150);
        bloodScreen.color = bloodAlpha;
        Color blackAlpha = blackScreen.color;
        blackAlpha.a = 1 - (player.playerStatManager.playerHealth * 2 / 100);
        blackScreen.color = blackAlpha;
    }
 
}
