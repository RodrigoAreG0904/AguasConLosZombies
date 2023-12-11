using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueAJugador : MonoBehaviour{

    [Header("Info")]
    public int ataque;

    void OnTriggerEnter(Collider collision) {
       if (collision.gameObject.tag == "Player"){
            MakeDamage(collision.gameObject);
            Debug.Log("Te pegó el zombie miilitar, te queda:"+ collision.gameObject.GetComponent<PlayerMove>().getVida());
       }
    }

    public void MakeDamage(GameObject player){
        int vidaDelJugador = player.GetComponent<PlayerMove>().getVida();
        vidaDelJugador = vidaDelJugador - ataque;
        player.GetComponent<PlayerMove>().setVida(vidaDelJugador);
    }
}