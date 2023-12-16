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

    public GameObject target;
    public bool atacando;
    public bool siendoAtacado;
    public Material rojo;
    public Material negro;
    private Material[] materialesZombie;
    private Transform zombie;

    [Header("Atributos")]
    public int vida;
    public int puntos;
    public int ataque;
    public int velocidadCaminar;
    public int velocidadCorrer;
    public int radioVista;
    public int radioAtaque;
    public GameObject handHitbox;

    void Start(){
        //vida = 100;
        //puntos = 5;
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
        if (transform.Find("Zombie") != null){
            zombie = transform.Find("Zombie");
        }
        if (transform.Find("Militar") != null){
            zombie = transform.Find("Militar");
        }
        materialesZombie = zombie.GetComponent<Renderer> ().materials;
    }

    // Update is called once per frame
    void Update(){
        Comportamiento_Enemigo();
    }

    public void Comportamiento_Enemigo(){
        //ani.SetBool("reactionHit", false);
        // si se murio, se murio
        if(vida <= 0){
            StopAttack();
            ani.SetBool("death", true);
            // Llama al método DestroyWithDelay después de 2 segundos
            Invoke("DestroyWithDelay", 3f);

        // tiene prioridad a que se le puede atacar en cualquier momento
        } else if(siendoAtacado){
            ani.SetBool("walk", false);
            ani.SetBool("run", false);
            StopAttack();
            ani.SetBool("reactionHit", true);
            Invoke("StopSiendoAtacado", 0.5f);
        // si el enemigo se encuentra a "radioVista" distancia del jugador hace su rutina normal
        }else if (Vector3.Distance(transform.position, target.transform.position) > radioVista && !siendoAtacado){
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
            if(Vector3.Distance(transform.position, target.transform.position) > radioAtaque && !atacando && !siendoAtacado){
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
        CambiarARojo();
        vida = vida - damage;
        siendoAtacado = true;
        barraDeVida.fillAmount = (float)vida/(float)vidaMax;
        if(vida <= 0){
            int puntosJugador = player.GetComponent<PlayerMove>().getPuntos();
            puntosJugador = puntosJugador + this.puntos;
            player.GetComponent<PlayerMove>().setPuntos(puntosJugador);
            //por si le da al zombie ya muerto
            this.puntos = 0;
        }
    }

    // Método que se llamará después del retraso
    private void DestroyWithDelay(){
        // Destruye el objeto después del retraso
        Destroy(gameObject);
    }

    private void StopSiendoAtacado(){
        ani.SetBool("reactionHit", false);
        siendoAtacado = false;
        CambiarANegro();
    }

    private void StopAttack(){
        ani.SetBool("attack", false);
        atacando = false;
    }

    public Animator getAnimator(){
        return ani;
    }

    public void CambiarARojo(){
        materialesZombie[1] = rojo;
        zombie.GetComponent<Renderer> ().materials = materialesZombie;
    }

    public void CambiarANegro(){
        materialesZombie[1] = negro;
        zombie.GetComponent<Renderer> ().materials = materialesZombie;
    }
}
