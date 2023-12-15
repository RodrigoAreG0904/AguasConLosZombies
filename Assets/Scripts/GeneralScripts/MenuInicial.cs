using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour{

    [Header("Pantallas")]
    public GameObject menuScreen;
    public GameObject confScreen;

    public GameObject instrScreen;

    public void Jugar(){
        SceneManager.LoadScene(2);
    }

    public void Instruction(){
        //playButton.SetActive(false);
        //confButton.SetActive(false);
        confScreen.SetActive(false);
        instrScreen.SetActive(true);
    }

    public void Salir(){
        Debug.Log("Salir");
        Application.Quit();
    }

    public void Config(){
        menuScreen.SetActive(false);
        confScreen.SetActive(true);
    }

    public void Return(){
        confScreen.SetActive(true);
        instrScreen.SetActive(false);
    }
}
