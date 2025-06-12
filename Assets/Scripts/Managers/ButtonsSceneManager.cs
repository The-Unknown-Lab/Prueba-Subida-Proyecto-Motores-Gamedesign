using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsSceneManager : MonoBehaviour
{
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Menu Principal");
    }
    public void ToHub()
    {
        //SceneManager.LoadScene()
        Debug.Log("Hub");

    }
    public void ToMinigameOne()
    {
        //SceneManager.LoadScene()
        Debug.Log("Minijuego");

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
