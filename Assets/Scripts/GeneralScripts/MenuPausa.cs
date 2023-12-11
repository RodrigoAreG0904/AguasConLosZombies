using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{

    public GameObject continueButton;
    public GameObject exitButton;
    public GameObject pauseScreen;
    public GameObject hitImage;

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
        continueButton.SetActive(false);
        exitButton.SetActive(false);
        pauseScreen.SetActive(false);
        hitImage.SetActive(true);
        onPause = !onPause;
    }

    public void Pause(){
        Time.timeScale = 0f;
        continueButton.SetActive(true);
        exitButton.SetActive(true);
        pauseScreen.SetActive(true);
        hitImage.SetActive(false);
        onPause = !onPause;
    }

    public void Salir(){
        Debug.Log("Salir");
        Application.Quit();
    }

}
