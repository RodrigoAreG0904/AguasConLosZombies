using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour{

    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;
    public Image barraDeVida;

    public int vidaMax;

    [Header("Info")]
    public int vida;
    public int puntos;
    public int velocidadCaminar;
    public int velocidadCorrer;
    public int radioVista;
    public int radioAtaque;

    public GameObject target;
    public bool atacando;
    // Start is called before the first frame update
    void Start(){
        vida = 100;
        puntos = 5;
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update(){
        Comportamiento_Enemigo();
    }

    public void Comportamiento_Enemigo(){
        // si se murio, se murio
        if(vida <= 0){
            StopAttack();
            ani.SetBool("death", true);
            // Llama al método DestroyWithDelay después de 2 segundos
            Invoke("DestroyWithDelay", 3f);
        // si el enemigo se encuentra a "radioVista" distancia del jugador hace su rutina normal
        }else if (Vector3.Distance(transform.position, target.transform.position) > radioVista){
            StopAttack();
            ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if(cronometro >=4){
                rutina = Random.Range(0,2);
                cronometro = 0;
            }
            switch (rutina){
                case 0:
                    ani.SetBool("walk",false);
                    break;

                case 1:
                    grado = Random.Range(0,360);
                    angulo = Quaternion.Euler(0,grado,0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * velocidadCaminar * Time.deltaTime);
                    ani.SetBool("walk",true);
                    break;
            }
        // si el enemigo esta menos de radioVista cerca del jugador la rutina cambia para ser hostil
        } else {
            StopAttack();
            // si esta en el campo de vision pero no en el de ataque, persigue al jugador
            if(Vector3.Distance(transform.position, target.transform.position) > radioAtaque && !atacando){
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                ani.SetBool("walk", false);

                ani.SetBool("run", true);
                transform.Translate(Vector3.forward * velocidadCorrer * 2 * Time.deltaTime);
            
            // si esta lo suficientemente cerca ataca al jugador
            } else {
                ani.SetBool("walk", false);
                ani.SetBool("run", false);

                ani.SetBool("attack", true);
                atacando = true;
            }
        }
    }

    public void TakeDamage(int damage, GameObject player){
        vida = vida - damage;
        barraDeVida.fillAmount = (float)vida/(float)vidaMax;
        int puntosJugador = player.GetComponent<PlayerMove>().getPuntos();
        puntosJugador = puntosJugador + this.puntos;
        player.GetComponent<PlayerMove>().setPuntos(puntosJugador);
    }

    // Método que se llamará después del retraso
    private void DestroyWithDelay(){
        // Destruye el objeto después del retraso
        Destroy(gameObject);
    }

    private void StopAttack(){
        // Destruye el objeto después del retraso
        ani.SetBool("attack", false);
        atacando = false;
    }
}
