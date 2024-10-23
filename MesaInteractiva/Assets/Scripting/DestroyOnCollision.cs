using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public int destructionCount = 0; // Contador de destrucción

    // Este método se llama cuando ocurre una colisión 2D
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificamos si el objeto con el que chocamos tiene una etiqueta específica (opcional)
        if (collision.gameObject.tag == "PalHueco")
        {
            // Destruir el objeto con el que colisionamos
            Destroy(collision.gameObject);
            
            // Aumentar el contador
            destructionCount++;
            
            // Mostrar el conteo de destrucción en la consola
            Debug.Log("Objetos destruidos: " + destructionCount);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
{
    if (other.gameObject.tag == "PalHueco")
    {
        Destroy(other.gameObject);
        destructionCount++;
        Debug.Log("Objetos destruidos: " + destructionCount);
    }
}

}
