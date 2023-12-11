using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake(){
        Instance = this;
    }

    public void Add(Item item){
        Items.Add(item);
    }

    public void Remove(Item item){
        Items.Remove(item);
    }

    public void ListItems(){
        Debug.Log("Entra al metodo");
        //Para que no se genere cada que el jugador abre el inventario
        foreach (Transform item in ItemContent){
            Destroy(item.gameObject);
        }
        Debug.Log("Sale del for limpiador");
        foreach(var item in Items){
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            Debug.Log("obj: " + obj);
            if(item == null){
                Debug.Log("El item es null");
            }
            Debug.Log("Nombre del ítem: " + item.itemName);
            Debug.Log("Icono del ítem: " + item.icon);

            if(itemName == null){
                Debug.Log("El itemName es null");
            }
            if(itemIcon == null){
                Debug.Log("El itemIcon es null");
            }

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }

        Debug.Log("Sale del for generador");
    }
}
