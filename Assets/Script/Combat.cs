using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Animator animator;

    public float attackRange = 0.5f;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackCooldown = 1f; // Cooldown de 1 segundo entre ataques
    private float lastAttackTime;

    void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (Time.time - lastAttackTime >= attackCooldown)
                {
                    Attack();
                    lastAttackTime = Time.time; // Actualiza el tiempo del �ltimo ataque
                }
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack1");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("hit");
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
