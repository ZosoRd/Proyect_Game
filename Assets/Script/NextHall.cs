using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextHall : MonoBehaviour
{
    public string nextSceneName;
    public KeyCode interactKey = KeyCode.E; // Tecla que el jugador debe presionar para interactuar

    private bool canLoadScene = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canLoadScene = true; // Habilita la carga de escena cuando el jugador entra en el collider
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canLoadScene = false; // Deshabilita la carga de escena cuando el jugador sale del collider
        }
    }

    private void Update()
    {
        if (canLoadScene && Input.GetKeyDown(interactKey)) // Verifica si se puede cargar la escena y se presionó la tecla definida
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName) && SceneManager.GetSceneByName(nextSceneName) != null)
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("No se pudo cargar la escena siguiente. Asegúrate de proporcionar un nombre de escena válido en el Inspector.");
        }
    }
}
