using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour{

    public GameObject playButton;
    public GameObject confButton;
    public GameObject confScreen;

    public void Jugar(){
        SceneManager.LoadScene(2);
    }

    public void Tutorial(){
        SceneManager.LoadScene(1);
    }

    public void Salir(){
        Debug.Log("Salir");
        Application.Quit();
    }

    public void Config(){
        playButton.SetActive(false);
        confButton.SetActive(false);
        confScreen.SetActive(true);
    }
}
