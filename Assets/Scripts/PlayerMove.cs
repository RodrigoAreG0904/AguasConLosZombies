using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour{

    public float runSpeed = 7;
    public float rotationSpeed = 250;

    public Animator animator;

    private float x, y;

    [Header("Info")]
    public int vida;
    public int puntos;

    void Start(){
        vida = 100;
        puntos = 0;
    }

    void Update(){
        if(this.vida <= 0){
            //aqui ponemos lo que se necesite cuando el jugador muere
            Debug.Log("Estas muerto");
        }

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x*Time.deltaTime*rotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime*runSpeed);

        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);
    }

    public int getVida(){
        return this.vida;
    }

    public void setVida(int vida){
        this.vida = vida;
    }

    public int getPuntos(){
        return this.puntos;
    }

    public void setPuntos(int puntos){
        this.puntos = puntos;
    }
}
