using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explorar : Interactable
{
    //comportamiento particular de explorar
    public override void Interact()
    {
        base.Interact();
        Destroy(gameObject);
        //presiona e para explorar
        //Entrega items
        //probabilidad de generar zombies
    }
}
