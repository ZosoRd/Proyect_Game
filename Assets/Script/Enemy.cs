using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    Animator animator; // Referencia al componente Animator

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>(); // Obtener el componente Animator

        EnemyManager.instance.RegisterEnemy(gameObject);

        // Iniciar con la animación de salud máxima (sprite original)
        if (animator != null)
        {
            animator.SetTrigger("MaxHealth"); // Activar trigger para animación de máxima salud
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Determinar el rango de vida actual
        float healthRatio = (float)currentHealth / maxHealth;

        // Seleccionar la animación según el rango de vida
        if (healthRatio <= 0.33f) // Menor o igual al 33%
        {
            if (animator != null)
            {
                animator.SetTrigger("LowHealth"); // Activar trigger para animación de baja salud
            }
        }
        else if (healthRatio <= 0.66f) // Menor o igual al 66%
        {
            if (animator != null)
            {
                animator.SetTrigger("MediumHealth"); // Activar trigger para animación de salud media
            }
        }
        else if (healthRatio <= 0.90f) // Más del 90
        {
            if (animator != null)
            {
                animator.SetTrigger("HighHealth"); // Activar trigger para animación de alta salud
            }
        }

        else
        {
            if (animator != null)
            {
                animator.SetTrigger("Full");
            }
        }

        // Verificar si el enemigo murió
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");

        // Disparar la animación de muerte
        if (animator != null)
        {
            animator.SetTrigger("Die"); // Activar trigger para animación de muerte
        }

        // Llamar al método del administrador de enemigos para eliminar este enemigo de la lista
        EnemyManager.instance.UnregisterEnemy(gameObject);

        // Aumentar el daño del jugador por eliminar este enemigo
        EnemyManager.instance.PlayerEliminatedEnemy();

        StartCoroutine(DestroyAfterDelay(1f));

    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Destruir el GameObject
        Destroy(gameObject);
    }
}