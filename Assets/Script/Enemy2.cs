using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public int maxHealth = 180;
    int currentHealth;



    void Start()
    {
        currentHealth = maxHealth;

        EnemyManager.instance.RegisterEnemy(gameObject);

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

    }

    void Die()
    {
        Debug.Log("Enemy died");

        // Llamar al método del administrador de enemigos para eliminar este enemigo de la lista
        EnemyManager.instance.UnregisterEnemy(gameObject);

        // Aumentar el daño del jugador por eliminar este enemigo
        EnemyManager.instance.PlayerEliminatedEnemy();

        Destroy(gameObject);

    }


    
}