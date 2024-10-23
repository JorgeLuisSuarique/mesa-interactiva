using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public GameObject canvasDialogo;  // Referencia al Canvas del diálogo

    private void OnMouseDown()
    {
        // Activar el Canvas y mostrar el mensaje del personaje al hacer clic
        canvasDialogo.SetActive(true);
    }

    public void CerrarDialogo()
    {
        // Cerrar el Canvas
        canvasDialogo.SetActive(false);
    }
}
