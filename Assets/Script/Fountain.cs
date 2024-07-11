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
            // Mostrar un mensaje de interacci�n (opcional)
            Debug.Log("Presiona 'E' para recuperar salud m�xima");

            // Guardar referencia al jugador para interactuar
            playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Limpiar la referencia al jugador al salir del �rea de interacci�n
            playerHealth = null;
        }
    }

    private void Update()
    {
        if (playerHealth != null && Input.GetKeyDown(interactKey))
        {
            // Restablecer la salud del jugador
            playerHealth.ResetPlayerHealth();

            // Desactivar el objeto despu�s de interactuar (opcional)
            gameObject.SetActive(false);
        }
    }
}