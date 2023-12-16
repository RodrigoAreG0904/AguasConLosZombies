using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public Item item;

    public void RemoveItem(){
        //InventoryManager.Instance.Remove(item);

        Destroy(gameObject);
    }

    public void AddItem(Item newItem){
        item = newItem;
    }

    public void UseItem(){

        switch(item.itemType){
            case Item.ItemType.Curacion:
                int vida = PlayerMove.Instance.getVida();
                if(vida < 100){
                    vida = vida + item.value;
                    if(vida > 100){
                        vida = 100;
                    }
                    PlayerMove.Instance.setVida(vida);
                    InventoryManager.Instance.Remove(item);
                    RemoveItem();
                }
                break;

            case Item.ItemType.Municion:
                //Cuando recarga busca la municion necesaria para el arma que lleva
                break;

            case Item.ItemType.Arma:
                string newWeaponName = item.itemName;
                string actualWeaponName = WeaponHolder.Instance.GetActiveWeaponName();
                WeaponHolder.Instance.DeactivateWeapon(actualWeaponName);
                WeaponHolder.Instance.ActivateWeapon(newWeaponName);
                InventoryManager.Instance.Remove(item);
                RemoveItem();
                break;

            case Item.ItemType.Tarjeta:
                //No puede hacer nada, solo llevarla a la atalaya
                break;
        }
    }
}
