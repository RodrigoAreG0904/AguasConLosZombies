using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item Item;

    void PickUp(){
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision) {
       if (collision.gameObject.tag == "Player"){
            PickUp();
       }
    }
}
