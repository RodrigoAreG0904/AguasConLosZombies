using UnityEngine;

public class Mira : MonoBehaviour
{
    public Camera aimCamera;
    public Texture2D texturaPunto;

    void OnGUI()
    {
        // Convierte las coordenadas del centro de la segunda cámara a coordenadas de pantalla
        Vector3 puntoEnPantalla = aimCamera.WorldToScreenPoint(transform.position);

        // Dibuja un punto rojo en el centro de la segunda cámara
        GUI.DrawTexture(new Rect(puntoEnPantalla.x - 10, Screen.height - puntoEnPantalla.y - 10, 20, 20), texturaPunto);
    }
}

