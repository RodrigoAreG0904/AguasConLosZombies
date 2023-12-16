using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuConfirmacion : MonoBehaviour
{

    public GameObject confirmScreen;
    public GameObject pauseScreen;

    public void ConfirmYes(){
        SceneManager.LoadScene(0);
    }

    public void ConfirmNo(){
        confirmScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }

}
