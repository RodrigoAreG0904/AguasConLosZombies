using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explorar : Interactable
{
    public int cantRec;
    private int recQueDa;
    //public Image menuRec; //El menu de los recursos al interactuar con una casa
    public Transform pos; //La posicion es temporal en lo que veo como sacar el menu, pero lo podemos usar para generar zombies

    public GameObject[] Recursos;
    public GameObject[] Spawn;
    public GameObject[] Enemigo;

    int s, e;

    //comportamiento particular de explorar
    public override void Interact()
    {
        base.Interact();

        if(recQueDa < cantRec)
        {
            //Entrega items
            instanciaRecurso();
        }
        else
        {
            //probabilidad de generar zombies
            //Destroy(gameObject);
            instanciaEnemigo();
        }
        
    }

    void instanciaRecurso()
    {
        int n = Random.Range(0, Recursos.Length);
        {
            Instantiate(Recursos[n], pos.position, Recursos[n].transform.rotation);
            recQueDa += 1;
        }
    }

    void instanciaEnemigo()
    {
        //sale3 en un spawn
        //s = Random.Range(0, 3); 
        //e = Random.Range(0, 3);
        for (int i = 0; i < 3; i++)
        {
            //Sale 1 por spawn
            s = Random.Range(0, 3);
            e = Random.Range(0, 3);
            Instantiate(Enemigo[e], Spawn[s].transform.position, Spawn[s].transform.rotation);
        }
    }
}
