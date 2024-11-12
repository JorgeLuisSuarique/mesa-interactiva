using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Añadido para la gestión de escenas

public class PanelManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject canvasPanel;  // Canvas que contiene los paneles
    public GameObject panelPrincipal;  // Panel del menú principal
    public GameObject panelDialogo;    // Panel de diálogo

    [Header("Botones")]
    public GameObject botonJuego;     // Botón para ir al juego
    public GameObject botonBarra;     // Botón para abrir el panel de diálogo
    public GameObject botonCerrar;    // Botón para cerrar el panel

    private void OnMouseDown()  // Método que se ejecuta cuando se hace clic en el objeto con el script
    {
        if (canvasPanel != null)
        {
            // Activa el canvas y el panel principal al hacer clic
            canvasPanel.SetActive(true);
            panelPrincipal.SetActive(true);
            ActivarDialogo();  // Activa el diálogo inmediatamente
        }
        else
        {
            Debug.LogWarning("Canvas no está asignado en el inspector.");
        }
    }

    private void Start()
    {
        // Asegura que el canvas esté inactivo al inicio
        if (canvasPanel != null)
        {
            canvasPanel.SetActive(false);
        }

        // Asignamos los botones de acción
        if (botonJuego != null)
        {
            botonJuego.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(Jugar);
        }

        if (botonBarra != null)
        {
            botonBarra.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(ActivarDialogo);
        }

        if (botonCerrar != null)
        {
            botonCerrar.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(CerrarPanel);
        }
    }

    public void Jugar()
    {
        // Código para cargar otra escena o realizar otra acción
        Debug.Log("Cargar juego");
        SceneManager.LoadScene("pool");  // Reemplaza "pool" con el nombre real de la escena
    }

    private void ActivarDialogo()
    {
        // Desactiva el panel principal y activa el panel de diálogo
        panelPrincipal.SetActive(false);
        panelDialogo.SetActive(true);
    }

    private void CerrarPanel()
    {
        // Desactiva todo el canvas
        if (canvasPanel != null)
        {
            canvasPanel.SetActive(false);  // Deja inactivo el canvas
        }
    }
}