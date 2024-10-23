using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PersonajeManager : MonoBehaviour
{
    public GameObject canvasDialogo;  // Referencia al Canvas del diálogo
    public Text dialogoText;          // Texto del diálogo en el Canvas
    public string mensaje;            // Mensaje que mostrará el personaje

    private void OnMouseDown()
    {
        // Activar el Canvas y mostrar el mensaje del personaje al hacer clic
        canvasDialogo.SetActive(true);
        dialogoText.text = mensaje;
    }

    public void JugarPool()
    {
        // Cambiar a la escena del pool
        SceneManager.LoadScene("pool");
    }

    public void CerrarDialogo()
    {
        // Cerrar el Canvas
        canvasDialogo.SetActive(false);
    }
}
