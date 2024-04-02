using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("Menu Config")]
    [SerializeField] private InputManager InputManager;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject ResumeButton;
    [SerializeField] private GameObject InventoryUI;
    public Slider HpBar;

    [SerializeField] private PlayerManager playerManager;
    public bool isPaused = false;
    public bool openInventory = false;

    private bool LockMouse;

    private void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }
    void Update()
    {
        MouseLockSet();
        enablePause();
        enableInventoryUI();
        HpBar.value = playerManager.playerStatManager.playerHealth / 100;
    }
    private void enablePause()
    {
        if (isPaused)
        {
            ActivateMenu();

            if (playerManager.playerStatManager.playerHealth <= 0)
            {
                ResumeButton.SetActive(false);
            }
        }
        else
        {
            DeactivateMenu();
        }
    }
    public void ActivateMenu()
    {
        // Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = false;
        LockMouse = true;
        AudioListener.pause = true;
        pauseUI.SetActive(true);

    }
    public void DeactivateMenu()
    {
        //Cursor.lockState = CursorLockMode.Locked;   
        AudioListener.pause = false;
        LockMouse = false;
        pauseUI.SetActive(false);
        isPaused = false;
    }
    public void Mainmenu()
    {
        isPaused = false;
        SceneManager.LoadSceneAsync("MainMenu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    private void enableInventoryUI()
    {
        if (openInventory)
        {
            ActiveInventoryUI();
        }
        else
        {
            DeactiveInventoryUI();
        }
    }
    public void ActiveInventoryUI()
    {
        
        //Cursor.lockState = CursorLockMode.None;
        InventoryUI.SetActive(true);
    }
    public void DeactiveInventoryUI()
    {
        
        //Cursor.lockState = CursorLockMode.Locked;
        InventoryUI.SetActive(false);
    }
    public void MouseLockSet()
    {
        if(LockMouse)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

}

