using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour{

    public Image barraDeVida;

    public float runSpeed = 7;
    public float rotationSpeed = 250;

    public Animator animator;

    private float x, y;

    public int vidaMax;

    [Header("Info")]
    public int vida;
    public int puntos;

    [Header("Inventario")]
    public GameObject inventarioUI;
    public GameObject inventoryManager;
    private bool inventarioActivo;

    [Header("GameOver")]

    public GameObject gameOverScreen;

    void Start(){
        //El sistema de guardado ya carga estos datos
        //vida = 100;
        //puntos = 0;
    }

    void Update(){
        if(this.vida <= 0){
            //aqui ponemos lo que se necesite cuando el jugador muere
            gameOverScreen.SetActive(true);
            Debug.Log("Estas muerto");
        }

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x*Time.deltaTime*rotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime*runSpeed);

        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);

        InventoryInput();
    }

    public int getVida(){
        return this.vida;
    }

    public void setVida(int vida){
        this.vida = vida;
        //cambiamos tambien la barra con la nueva vida
        barraDeVida.fillAmount = (float)vida / (float)vidaMax;
        
    }

    public int getPuntos(){
        return this.puntos;
    }

    public void setPuntos(int puntos){
        this.puntos = puntos;
    }

    private void InventoryInput(){
        if (Input.GetKeyDown(KeyCode.I)){ 
            AbrirCerrarInventario();
            inventarioActivo = !inventarioActivo;
        }
    }

     void AbrirCerrarInventario(){
        if(inventarioActivo){
            inventarioUI.SetActive(false);
        }else{
            inventoryManager.gameObject.GetComponent<InventoryManager>().ListItems();
            inventarioUI.SetActive(true);
        }
    }
}
