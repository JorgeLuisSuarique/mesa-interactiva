using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PersonajeManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI dialogoText;  // Texto de diálogo
    public Button closeButton;  // Botón para cerrar el diálogo
    public Button nextButton;  // Botón para avanzar en el diálogo
    public GameObject panelPrincipal;  // Panel principal (se activa cuando se cierra el diálogo)
    public GameObject panelDialogo;  // Panel de diálogo (se desactiva al cerrar)

    [Header("Dialogues")]
    [TextArea(3, 5)]
    public string[] mensajes;  // Lista de mensajes de diálogo
    private int indiceMensaje = 0;  // Índice actual del mensaje en la lista

    [Header("Typing Effect Settings")]
    public float velocidadEscritura = 0.05f;  // Velocidad del efecto de máquina de escribir

    private Coroutine typingCoroutine;
    private bool escribiendo = false; // Para controlar si el texto está siendo escrito

    private void Start()
    {
        // Configura el botón de cerrar para que llame al método CerrarDialogo
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CerrarDialogo);
        }
        else
        {
            Debug.LogWarning("El botón de cerrar no está asignado en el inspector.");
        }

        // Configura el botón de siguiente para que llame al método SiguienteDialogo
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(SiguienteDialogo);
        }
        else
        {
            Debug.LogWarning("El botón de siguiente no está asignado en el inspector.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Escape para cerrar el diálogo
        {
            CerrarDialogo();
        }
    }

    // Método para abrir el diálogo, reiniciar el índice y mostrar el primer mensaje
    public void AbrirDialogo()
    {
        if (panelDialogo != null)
        {
            panelDialogo.SetActive(true);  // Activa el panel de diálogo
        }

        indiceMensaje = 0;  // Reinicia el índice al abrir el diálogo
        MostrarMensajeActual();  // Muestra el primer mensaje con efecto
    }

    // Método para cerrar el diálogo
    public void CerrarDialogo()
    {
        if (panelDialogo != null)
        {
            panelDialogo.SetActive(false);  // Desactiva el panel de diálogo
        }
        if (panelPrincipal != null)
        {
            panelPrincipal.SetActive(true);  // Activa el panel principal
        }
        indiceMensaje = 0;  // Reinicia el índice del mensaje
        dialogoText.text = "";  // Limpia el texto del diálogo
    }

    // Método para avanzar al siguiente diálogo
    public void SiguienteDialogo()
    {
        if (escribiendo) return;  // Si el texto aún se está escribiendo, no se puede avanzar

        if (indiceMensaje < mensajes.Length - 1)
        {
            indiceMensaje++;
            MostrarMensajeActual();  // Muestra el siguiente mensaje con efecto
        }
        else
        {
            CerrarDialogo();  // Cierra el diálogo si llega al final de la lista
        }
    }

    // Muestra el mensaje actual con el efecto de máquina de escribir
    private void MostrarMensajeActual()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);  // Detiene la escritura anterior si estaba activa
        }
        typingCoroutine = StartCoroutine(EscribirTexto(mensajes[indiceMensaje]));
    }

    // Coroutine para el efecto de máquina de escribir
    private IEnumerator EscribirTexto(string mensaje)
    {
        escribiendo = true;  // Indica que el texto está siendo escrito
        dialogoText.text = "";  // Limpia el texto antes de comenzar a escribir

        foreach (char letra in mensaje.ToCharArray())
        {
            dialogoText.text += letra;  // Añade letra por letra
            yield return new WaitForSeconds(velocidadEscritura);  // Pausa para el efecto de escritura
        }

        escribiendo = false;  // Termina el proceso de escritura
    }
}