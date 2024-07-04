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

        Destroy(gameObject, 0.5f);

        // Aquí podrías agregar código adicional al morir, como desactivar el GameObject, reproducir efectos de sonido, etc.
        // Ejemplo:
        // gameObject.SetActive(false);
    }
}