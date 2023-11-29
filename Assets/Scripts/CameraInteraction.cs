using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteraction : MonoBehaviour
{
    private new Transform camera;
    public float rayDistance;

    public GameObject DetectaTexto;

    // Start is called before the first frame update
    void Start()
    {
        camera = transform.Find("Aim Camera");
        DetectaTexto.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(camera.position, camera.forward * rayDistance, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, rayDistance, LayerMask.GetMask("Interactivo")))
        {
            //Debug.Log(hit.transform.name);
            DetectaTexto.SetActive(true);
            if (Input.GetButtonDown("Interactivo"))
            {
                hit.transform.GetComponent<Interactable>().Interact();
                DetectaTexto.SetActive(false);
            }
        }
        else
        {
            DetectaTexto.SetActive(false);
        }
    }

}
