using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{

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
