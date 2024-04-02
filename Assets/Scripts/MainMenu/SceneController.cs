using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [Header("Menu Config")]
    [SerializeField] private Button newGameButton;

    public void StartGamePlay()
    {
       
        SceneManager.LoadSceneAsync("Opening");

    }

    public void EndGame()
    {
        
        SceneManager.LoadSceneAsync("Ending");

    }
    public void GamePlay()
    {
        
        SceneManager.LoadSceneAsync("GamePlay");

    }
    public void Intro()
    {

        SceneManager.LoadSceneAsync("Intro");

    }

    public void MainMenu()
    {

        SceneManager.LoadSceneAsync("MainMenu");

    }


    public void ExitGame()
    {
        Application.Quit();
    }

  

}
