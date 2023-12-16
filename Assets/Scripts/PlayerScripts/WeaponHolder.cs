using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script creado para regresar las armas del weapon holder mas rapido
public class WeaponHolder : MonoBehaviour{
    
    public static WeaponHolder Instance;

    private string activeWeaponName = "pistol";

    void Awake(){
        Instance = this;
    }

    public void ActivateWeapon(string weaponName){
        SetWeaponActive(weaponName, true);
    }

    public void DeactivateWeapon(string weaponName){
        SetWeaponActive(weaponName, false);
    }

    private void SetWeaponActive(string weaponName, bool active){
        Transform weapon = transform.Find(weaponName);
        if (weapon != null){
            weapon.gameObject.SetActive(active);
            // Actualizar el nombre del arma activa solo si se activa
            if (active)
            {
                activeWeaponName = weaponName;
            }
        }else{
            Debug.LogWarning($"Weapon with name {weaponName} not found.");
        }
    }

    public string GetActiveWeaponName(){
        return activeWeaponName;
    }
}
