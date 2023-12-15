using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{

    public GameObject camara;
    public GameObject player;

    [Header("Pantallas")]
    public GameObject pauseScreen;
    public GameObject menuScreen;
    public GameObject confirmScreen;

    public bool onPause = false;

    private void Update(){
        if(Input.GetKeyDown(KeyCode.P)){
            if(!onPause){
                Pause();
            }else{
                Continue();
            }
        }
    }

    public void Continue(){
        Time.timeScale = 1f;
        camara.SetActive(false);
        player.SetActive(true);
        pauseScreen.SetActive(false);
        onPause = !onPause;
    }

    public void Pause(){
        Time.timeScale = 0f;
        camara.SetActive(true);
        player.SetActive(false);
        pauseScreen.SetActive(true);
        onPause = !onPause;
    }

    public void MenuConfirm(){
        confirmScreen.SetActive(true);
        menuScreen.SetActive(false);
    }

    public void Salir(){
        Debug.Log("Salir");
        Application.Quit();
    }

}
