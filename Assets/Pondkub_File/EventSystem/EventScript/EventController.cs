using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventController : MonoBehaviour
{
    //_________________________Object______________________//
    public GameObject Alien_SMarket;

    public GameObject[] Alien_ComRoom;
    public GameObject Alien_DataRoom;
    public GameObject[] Alien_FindRunner;
    public GameObject Alien_FightRunner;
    public GameObject[] Alien_PhaseII;
    public GameObject Alien_SleepRoom;
    public GameObject[] Alien_Storage;
    public GameObject[] Alien_NonShortcutWay;
    public GameObject Alien_TroubleFirstTime;
    public GameObject Alien_Boss;

    //________________________HitBox_______________________//
    public GameObject Event_SMarket;   //1-2
    public GameObject Event_TruckBroken;//3-4
    public GameObject Event_FindDoor;//5-6
    //public GameObject Event_GetKeyStair;
    public GameObject Event_TruckBroken2; //7
    public GameObject Event_GetItemQuest; //
    


    //________________________SFX_________________________//
    public GameObject SFX_ObjectDrop;
    public GameObject SFX_BreakDoor;

    //_______________________Panel_______________________//
    public GameObject Panel_SMarket;
    public GameObject[] Panel_TruckBroken;
    public GameObject[] Panel_FindDoor;
    public GameObject Panel_GetKeyStair;
    public GameObject Panel_DataDoor;
    public GameObject Panel_GetPinkKey;
    public GameObject Panel_AlienDataRoom;
    public GameObject Panel_FindRunner;


    


    //________________________RunEvent___________________//
    public static int RunEvent;

   


    //_______________________player______________________//
    public GameObject EventPlayer;
    public static GameObject player;

    private void Start()
    {
        player = EventPlayer;
    }
    private void Update()
    {
        
        Stage_SMarket();      //1-2
        Stage_TruckBroken();  //3-4
        Stage_FindDoor();     //5-6
        Stage_GetKeyStair();  //7-8
        Stage_DataDoor();     //9-10
        Stage_ComDoor();      //11
        Stage_GetPinkKey();   //12-13
        Stage_AlienDataRoom();//14 -15
        Stage_FindRunner();   //16-18
        Stage_FightRunner();  //19
        Stage_SleepRoom();    //20
        Stage_Storage();      //21
        Stage_TroubleFirstTime(); //22
        //Stage_BossOpen();//23
        Debug.Log("Run  == " + RunEvent);


    }
    //___________________________________________Event1___//
    void Stage_SMarket()
    {
        if(RunEvent == 1)
        {  
            Alien_SMarket.SetActive(true);
            SFX_ObjectDrop.SetActive(true);
            TutorialController.RunTutorial = -1;
            if (SMarket_Event.OpenPanelDelay)
            {
                Panel_SMarket.SetActive(true);
            }
        }
        else
        {
            Panel_SMarket.SetActive(false);
            SFX_ObjectDrop.SetActive(false);
            Panel_SMarket.SetActive(false);
            //Event_SMarket.SetActive(false);
        }
        if (RunEvent == 2)
        {

            Event_SMarket.SetActive(false);
        }
    }
    //___________________________________________Event2___//
    void Stage_TruckBroken()
    {
        if(RunEvent == 3)
        {
            //Debug.Log("Eiei  = "+TruckBroken_Event.PanelCheck_Number[TruckBroken_Event.RunPanel]);
            

            if (TruckBroken_Event.RunPanel == 0) //first
            {
                Panel_TruckBroken[0].SetActive(true);
            }
            else if(TruckBroken_Event.RunPanel == 1)
            {
                Panel_TruckBroken[1].SetActive(true);
                Panel_TruckBroken[0].SetActive(false);
            }
            else if(TruckBroken_Event.RunPanel==2) //last
            {
                Panel_TruckBroken[2].SetActive(true);
                Panel_TruckBroken[1].SetActive(false);
            }
       

        }
        else
        {
            Panel_TruckBroken[0].SetActive(false);
            Panel_TruckBroken[1].SetActive(false);
            Panel_TruckBroken[2].SetActive(false);
        }
        if (RunEvent == 4)
        {

            Event_TruckBroken.SetActive(false);

        }
    }
    //___________________________________________Event3___//
    void Stage_FindDoor()
    {
        if(RunEvent == 5)
        {

            Event_TruckBroken.SetActive(false);
            if (FindDoor_Event.RunPanel)
            {
                Panel_TruckBroken[2].SetActive(false);
                Panel_FindDoor[1].SetActive(true);
                Panel_FindDoor[0].SetActive(false);
            }
            else if(!FindDoor_Event.RunPanel)
            {
                Panel_FindDoor[0].SetActive(true);
            }
        }
        else if(RunEvent == 6)
        {
            Event_FindDoor.SetActive(false);
            Panel_FindDoor[1].SetActive(false);
            Panel_FindDoor[0].SetActive(false);
        }
    }
    void Stage_GetKeyStair()
    {
        if(RunEvent == 7)
        {
            Event_TruckBroken2.SetActive(true);
            Panel_GetKeyStair.SetActive(true);
        }
        else if(RunEvent == 8)
        {
            Panel_GetKeyStair.SetActive(false);
        }
    }
    void Stage_DataDoor()
    {
        if (RunEvent == 9)
        {
            Panel_DataDoor.SetActive(true);
        }
        else if(RunEvent == 10)
        {
            Panel_DataDoor.SetActive(false);
        }
    }
    void Stage_ComDoor()
    {
        if(RunEvent == 11)
        {
            Alien_ComRoom[0].SetActive(true);
            Alien_ComRoom[1].SetActive(true);
            RunEvent = 0;
        }
    }
    void Stage_GetPinkKey()
    {
        if (RunEvent == 12)
        {
            Panel_GetPinkKey.SetActive(true);
        }
        else if (RunEvent == 13)
        {
            Panel_GetPinkKey.SetActive(false);
        }
    }
    void Stage_AlienDataRoom()
    {
        if (RunEvent == 14)

        {
            Panel_AlienDataRoom.SetActive(true);
            Alien_DataRoom.SetActive(true);
            SFX_BreakDoor.SetActive(true);
            Alien_NonShortcutWay[0].SetActive(true);
            
            
        }
        if(RunEvent == 15)
        {

            Panel_AlienDataRoom.SetActive(false);
            Destroy(Event_GetItemQuest);
        }

    }
    void Stage_FindRunner()
    {
        if(RunEvent == 16)
        {
            Alien_FindRunner[0].SetActive(true);
            Alien_FindRunner[1].SetActive(true);
        }
        if(RunEvent == 17)
        {
            //Panel_FindRunner.SetActive(true);
        }
        if (RunEvent == 18)
        {
            //Panel_FindRunner.SetActive(false);
            //Alien_FindRunner[0].SetActive(false);
            
        }
    }
    void Stage_FightRunner()
    {
        if(RunEvent == 19)
        {
            Alien_FightRunner.SetActive(true);
            Alien_PhaseII[0].SetActive(true);
            Alien_PhaseII[1].SetActive(true);
            Alien_PhaseII[2].SetActive(true);
            Alien_PhaseII[3].SetActive(true);

            RunEvent = 0;
        }
    }
    void Stage_SleepRoom()
    {
        if (RunEvent == 20)
        {
            Alien_SleepRoom.SetActive(true);
            RunEvent = 0;
        }
    }
    void Stage_Storage()
    {
        if (RunEvent == 21)
        {
            Alien_Storage[0].SetActive(true);
            Alien_Storage[1].SetActive(true);
            RunEvent = 0;
        }
    }

    void Stage_TroubleFirstTime()
    {
        if (RunEvent == 22)
        {
            Alien_TroubleFirstTime.SetActive(true);
            RunEvent = 0;
        }
    }
    void Stage_BossOpen()
    {
        if (RunEvent == 23)
        {
            Alien_Boss.SetActive(true);
            RunEvent = 0;
        }
    }

}
