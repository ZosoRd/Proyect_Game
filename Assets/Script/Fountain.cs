using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E; // Tecla que el jugador debe presionar para interactuar
    public PlayerHealth playerHealth; // Referencia al script PlayerHealth

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Mostrar un mensaje de interacción (opcional)
            Debug.Log("Presiona 'E' para recuperar salud máxima");

            // Guardar referencia al jugador para interactuar
            playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Limpiar la referencia al jugador al salir del área de interacción
            playerHealth = null;
        }
    }

    private void Update()
    {
        if (playerHealth != null && Input.GetKeyDown(interactKey))
        {
            // Restablecer la salud del jugador
            playerHealth.ResetPlayerHealth();

            // Desactivar el objeto después de interactuar (opcional)
            gameObject.SetActive(false);
        }
    }
}