using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PersonajeManager : MonoBehaviour
{
   public GameObject canvasDialogo;   // Canvas del personaje
    public Text dialogoText;           // Texto del diálogo en el Canvas
    public string mensaje;             // Mensaje del personaje

    public Camera mainCamera;          // Cámara principal
    public Transform personajeTarget;  // Transform del personaje 3D al que la cámara se acercará

    public float duracionTransicion = 1.5f;  // Duración de la transición de la cámara
    private Vector3 posicionInicialCamara;   // Posición original de la cámara
    private Quaternion rotacionInicialCamara; // Rotación original de la cámara

    private void Start()
    {
        // Guardar la posición y rotación original de la cámara al inicio
        posicionInicialCamara = mainCamera.transform.position;
        rotacionInicialCamara = mainCamera.transform.rotation;
    }

    private void OnMouseDown()
    {
        // Inicia la transición de la cámara hacia el personaje 3D
        StartCoroutine(MoverCamara());
    }

    IEnumerator MoverCamara()
    {
        float tiempo = 0;

        Vector3 posicionObjetivo = personajeTarget.position + new Vector3(0f,0f, 0f); // Ajustar para que la cámara mire al personaje
        Quaternion rotacionObjetivo = Quaternion.Euler(0, 90, -90);

        // Transición suave entre la posición inicial y la del personaje
        while (tiempo < duracionTransicion)
        {
            mainCamera.transform.position = Vector3.Lerp(posicionInicialCamara, posicionObjetivo, tiempo / duracionTransicion);
            mainCamera.transform.rotation = Quaternion.Lerp(rotacionInicialCamara, rotacionObjetivo, tiempo / duracionTransicion);
            tiempo += Time.deltaTime;
            yield return null;
        }

        // Asegurar que la cámara esté exactamente en la posición y rotación finales
        mainCamera.transform.position = posicionObjetivo;
        mainCamera.transform.rotation = rotacionObjetivo;

        // Activar el Canvas del diálogo y mostrar el mensaje
        canvasDialogo.SetActive(true);
        dialogoText.text = mensaje;
    }

    public void CerrarDialogo()
    {
        // Cierra el Canvas y devuelve la cámara a su posición original
        canvasDialogo.SetActive(false);
        StartCoroutine(ResetearCamara());
    }

    IEnumerator ResetearCamara()
    {
        float tiempo = 0;

        // Transición suave para devolver la cámara a su posición original
        while (tiempo < duracionTransicion)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, posicionInicialCamara, tiempo / duracionTransicion);
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, rotacionInicialCamara, tiempo / duracionTransicion);
            tiempo += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = posicionInicialCamara;
        mainCamera.transform.rotation = rotacionInicialCamara;
    }
}

