using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{

    public GameObject menuGameOver;

    private void Update(){
        if(Input.GetKeyDown(KeyCode.M)){
            GameOver();
        }
    }

    public void GameOver(){
        menuGameOver.SetActive(true);
    }

    public void TryAgain(){
        
    }

    public void Menu(){
        SceneManager.LoadScene(0);
    }

    public void Salir(){
        Debug.Log("Salir");
        Application.Quit();
    }

}
