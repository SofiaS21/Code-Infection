using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaras : MonoBehaviour
{
    public Camera[] camaras;
    public GameObject panelCamaras;
    public TMPro.textMeshProUGUI nombreCamaraTexto;

    int indiceActual = 0;

    void Start()
    {
        foreach (Camera cam in camaras)
            cam.enabled = false;

        panelCamaras.SetActive(false);
    }

    void Update()
    {
        if (!panelCamaras.activeself) return; // si no está activo, ignoramos input

        if (Input.GetKeyDown(Keycode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            CambiarCamara(1);

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            CambiarCamara(-1);
    }

    public void Activar()
    {
        panelCamaras.SetActive(true);
        MostrarCamara(indiceActual);
    }

    public void Desactivar()
    {
        camaras[indiceActual].enabled = false;
        panelCamaras.SetActive(false);
    }

    void CambiarCamara(int direccion)
    {
        camaras[indiceActual].enabled = false;

        indiceActual += direccion;
        if (indiceActual >= camaras.Length) indiceActual = 0;
        if (indiceActual < 0) indiceActual = camaras.Length - 1;

        MostrarCamara(indiceActual);
    }

    void MostrarCamara(int i)
    {
        camaras[i].enabled = true;

        if (nombreCamaraTexto != null)
            nombreCamaraTexto.text = "CAM " + (i + 1) + " - " + camaras[i].name;
    }

}
