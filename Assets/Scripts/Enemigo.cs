using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour{

    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;

    [Header("Info")]
    public int vida;
    public int puntos;
    // Start is called before the first frame update
    void Start(){
        vida = 100;
        puntos = 5;
        //ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        Comportamiento_Enemigo();
    }

    public void Comportamiento_Enemigo(){
        cronometro += 1 * Time.deltaTime;
        if(cronometro >=4){
            rutina = Random.Range(0,2);
            cronometro = 0;
        }
        switch (rutina){
            case 0:
                //ani.SetBool("walk",false);
                break;

            case 1:
                grado = Random.Range(0,360);
                angulo = Quaternion.Euler(0,grado,0);
                rutina++;
                break;
            case 2:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                //ani.SetBool("walk",true);
                break;
        }
    }

    public void TakeDamage(int damage, GameObject player){
        vida = vida - damage;
        if(vida <= 0){
           int puntosJugador = player.GetComponent<PlayerMove>().getPuntos();
           puntosJugador = puntosJugador + this.puntos;
           player.GetComponent<PlayerMove>().setPuntos(puntosJugador);
           Destroy(gameObject);
        }
    }
}
