using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WeaponController: MonoBehaviour
{
    [Header("Weapon Controller")]
    [SerializeField] private PlayerInput playerInput;
    public GameObject revolverGun;
    [SerializeField] private GameObject revolverGunController;
    public GameObject ShotGun;
    [SerializeField] private GameObject shotGunController;
    public GameObject assaultRifleGun;
    [SerializeField] private GameObject assaultRifleGunController;
    public GameObject malee;
    [SerializeField] private GameObject maleeController;
    [Header("UI")]
    public GameObject revolverCanvas;
    public GameObject ShotgunCanvas;
    public GameObject assaultRifleCanvas;

    private InputAction switchWaepon1;
    private InputAction switchWaepon2;
    private InputAction switchWaepon3;
    private InputAction switchWaepon4;
    
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slotOne();
        slotTwo();
        slotThree();
        slotFour();
    }

    private void slotOne()
    {

        switchWaepon1 = playerInput.actions["Slot1"];

        if (switchWaepon1.triggered)
        {
            revolverGun.SetActive(true);
            revolverGunController.SetActive(true);
            ShotGun.SetActive(false);
            shotGunController.SetActive(false);
            assaultRifleGun.SetActive(false);
            assaultRifleGunController.SetActive(false);
            malee.SetActive(false);
            maleeController.SetActive(false);

            revolverCanvas.SetActive(true);
            ShotgunCanvas.SetActive(false);
            assaultRifleCanvas.SetActive(false);
        }
    }
    private void slotTwo()
    {
        
        switchWaepon2 = playerInput.actions["Slot2"];

        
        if (switchWaepon2.triggered)
        {
            revolverGun.SetActive(false);
            revolverGunController.SetActive(false);
            ShotGun.SetActive(true);
            shotGunController.SetActive(true);
            assaultRifleGun.SetActive(false);
            assaultRifleGunController.SetActive(false);
            malee.SetActive(false);
            maleeController.SetActive(false);

            revolverCanvas.SetActive(false);
            ShotgunCanvas.SetActive(true);
            assaultRifleCanvas.SetActive(false);
        }
    }
    private void slotThree()
    {
        switchWaepon3 = playerInput.actions["Slot3"];

        if (switchWaepon3.triggered)
        {
            revolverGun.SetActive(false);
            revolverGunController.SetActive(false);
            ShotGun.SetActive(false);
            shotGunController.SetActive(false);
            assaultRifleGun.SetActive(true);
            assaultRifleGunController.SetActive(true);
            malee.SetActive(false);
            maleeController.SetActive(false);

            revolverCanvas.SetActive(false);
            ShotgunCanvas.SetActive(false);
            assaultRifleCanvas.SetActive(true);
        }
    }
    private void slotFour()
    {
        switchWaepon4 = playerInput.actions["Slot4"];

        if (switchWaepon4.triggered)
        {
            revolverGun.SetActive(false);
            revolverGunController.SetActive(false);
            ShotGun.SetActive(false);
            shotGunController.SetActive(false);
            assaultRifleGun.SetActive(false);
            assaultRifleGunController.SetActive(false);
            malee.SetActive(true);
            maleeController.SetActive(true);
        }
    }
}
