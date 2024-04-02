using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public static int TutorialPanal_Stage = 0;

    public GameObject EventPlayer;
    public static GameObject player;

    

    //_____________________HitBox Object______________________//
    public GameObject Stage_BasicControl;       //Stage 1
    public GameObject Stage_FindItem;           //Stage 2
    public GameObject Stage_Heal;               //Stage 3   
    public GameObject Stage_OpenDoor;           //Stage 4
    public GameObject Stage_inventory;          //Stage 5
    public GameObject Stage_Run;                //Stage 6        
    public GameObject Stage_Reload;             //Stage 7
    public GameObject Stage_FireGun;            //Stage 8




    public int a_____________________________a;
    //____________________Panel Object______________________//
    
    public GameObject Panel_BasicControl;
    public GameObject Panel_FindItem;
   // public GameObject Panel_GetHeal;
    public GameObject Panel_Heal;
    public GameObject Panel_KeyItem;
    public GameObject Panel_OpenDoor;
    public GameObject Panel_Run;
    public GameObject Panel_Reload;
    public GameObject Panel_Fire;

    


    

    //____________________Get Value__________________________//
    public static int RunTutorial;



    //__________________Tutorial End_________________________//
    //public GameObject Tutorial_Controller;

    private void Start()
    {
        player = EventPlayer;

        //Panel_BasicControl.SetActive(false);
        //Panel_FindItem.SetActive(false);
        //Panel_Fire.SetActive(false);
        //Panel_Heal.SetActive(false);
        //Panel_KeyItem.SetActive(false);
        //Panel_OpenDoor.SetActive(false);
        //Panel_Reload.SetActive(false);
        //Panel_Run.SetActive(false);
    }
    private void Update()
    {
        //Debug.Log("Run" + RunTutorial);
        BasicControl_Tutorial();
        FindItem_Tutorial();
        Heal_Tutorial();
        OpenDoor_Tutorial();
        Inventory_Tutorial();
        Run_Toturial();
        Reload_Toturial();
        Fire_Tutorial();
        Destroy_TutorialController();
        

    }
    void FindItem_Tutorial()
    {
        if (RunTutorial == 2)
        {
            Panel_FindItem.SetActive(true);
        }
        else 
        {
            Panel_FindItem.SetActive(false);
            Stage_FindItem.SetActive(false);
        }
    }
    void BasicControl_Tutorial()
    {
        if(RunTutorial==1)
        {
            Panel_BasicControl.SetActive(true);
        }
        else 
        {
            Panel_BasicControl.SetActive(false);
            Stage_BasicControl.SetActive(false);
            Stage_FindItem.SetActive(true);
        }
    }
    void Heal_Tutorial()
    {
        if (RunTutorial == 3)
        {
            Panel_Heal.SetActive(true);
            Stage_Heal.SetActive(true);
            if (Input.GetKeyDown(KeyCode.B))
            {
                Stage_Heal.SetActive(false);
                Stage_OpenDoor.SetActive(true);
                Panel_Heal.SetActive(false);
                RunTutorial = 0;
            }
        }
        else 
        {
            Panel_Heal.SetActive(false);
            
        }
    }
    void OpenDoor_Tutorial()
    {
        if (RunTutorial == 4)
        {
            Panel_OpenDoor.SetActive(true);
        }
        else 
        {
            Panel_OpenDoor.SetActive(false);
            
        }
    }
    void Inventory_Tutorial()
    {
        if (RunTutorial == 5)
        {
            Panel_KeyItem.SetActive(true);
            Panel_Heal.SetActive(false);
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                Stage_inventory.SetActive(false);
                RunTutorial = 0;
            }
        }
        else 
        {
            Panel_KeyItem.SetActive(false);
            
            
        }
    }
    void Run_Toturial()
    {
        if (RunTutorial == 6)
        {
            Panel_Run.SetActive(true);
            
        }
        else 
        {
            Panel_Run.SetActive(false);
        }
    }
    void Reload_Toturial()
    {
        if(RunTutorial == 7)
        {
            Panel_Reload.SetActive(true);
            
        }
        else 
        {
            Panel_Reload.SetActive(false);
            
            
        }
    }
    void Fire_Tutorial()
    {
        if(RunTutorial == 8)
        {
            Stage_FireGun.SetActive(true);
            Panel_Fire.SetActive(true);
        }
        else 
        {
            Panel_Fire.SetActive(false);
        }
    }
    void Destroy_TutorialController()
    {
        if(RunTutorial == -1)
        {
            Destroy(gameObject);

        }
    }
    
}
