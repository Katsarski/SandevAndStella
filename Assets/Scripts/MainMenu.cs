using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject CanvasCredits;



    public void StartGame()
    {

        SceneManager.LoadScene("Test");
    }


    public void OpenCredits()
    {
        CanvasCredits.SetActive(true);
    }


    public void CloseCredits()
    {
        CanvasCredits.SetActive(false);
    }


   
}
