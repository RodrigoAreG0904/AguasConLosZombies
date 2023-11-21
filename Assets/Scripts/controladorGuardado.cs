using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class controladorGuardado : MonoBehaviour{
    
    public GameObject player;
    public string archivoGuardado;
    DatoGuardado dg = new DatoGuardado();

    private void Awake(){
        archivoGuardado = Application.dataPath + "/GameData.json";
        player = GameObject.FindGameObjectWithTag("Player");
        LoadData();
    }

    public void Update(){
        if (Input.GetKeyDown(KeyCode.G)){
            SaveData();
        }
        if (Input.GetKeyDown(KeyCode.L)){
            LoadData();
        }
    }

    private void LoadData(){
        if(File.Exists(archivoGuardado)){
            string contenido = File.ReadAllText(archivoGuardado);
            dg = JsonUtility.FromJson<DatoGuardado>(contenido);
            player.transform.position = dg.posicion;
            player.GetComponent<PlayerMove>().vida = dg.vida;
            player.GetComponent<PlayerMove>().puntos = dg.puntos;
        }
    }

    private void SaveData(){
        DatoGuardado nuevosDatos = new DatoGuardado(){
            posicion = player.transform.position,
            vida = player.GetComponent<PlayerMove>().vida,
            puntos = player.GetComponent<PlayerMove>().puntos
        };
        string datoAGuardar = JsonUtility.ToJson(nuevosDatos);
        Debug.Log(datoAGuardar);
        File.WriteAllText(archivoGuardado, datoAGuardar);
    }
}
