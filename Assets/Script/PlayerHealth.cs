using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para gestionar las escenas

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public Animator animator;

    public string healthSaveKey = "PlayerHealth";

    [SerializeField] GameOver gameOverScript;

    void Start()
    {
        // Cargar la vida guardada al inicio del juego, o usar el valor predeterminado
        currentHealth = PlayerPrefs.GetInt(healthSaveKey, maxHealth);
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(10);
            Debug.Log("daño");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (animator != null)
        {
            animator.SetTrigger("TakeHit");
        }

        if (currentHealth <= 0)
        {
            gameOverScript.ShowGameOverMenu();
        }

        // Guardar la vida actual en PlayerPrefs
        PlayerPrefs.SetInt(healthSaveKey, currentHealth);
        PlayerPrefs.Save(); // Asegurarse de guardar los datos inmediatamente
    }

    // Limpiar datos al salir del juego
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey(healthSaveKey); // Eliminar la clave al salir
        PlayerPrefs.Save(); // Asegurarse de guardar los cambios
    }

    public void ResetPlayerHealth()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);

        // Guardar la vida reiniciada en PlayerPrefs
        PlayerPrefs.SetInt(healthSaveKey, currentHealth);
        PlayerPrefs.Save(); // Asegurarse de guardar los datos inmediatamente
    }
}

