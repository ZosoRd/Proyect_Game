using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Animator animator;

    public float attackRange = 0.5f;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackCooldown = 1f; 
    private float lastAttackTime;


    private int comboState = 0; 

    void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (Time.time - lastAttackTime >= attackCooldown)
                {
                    Attack();
                    lastAttackTime = Time.time; 
                }
            }
        }
    }

    void Attack()
    {
        
            switch (comboState)
            {
                case 0:  
                    animator.SetTrigger("Attack1");
                    lastAttackTime = Time.time;
                    comboState = 1;
                    break;
                case 1:  
                    animator.SetTrigger("Attack2");
                    lastAttackTime = Time.time;
                    comboState = 2;
                    break;
                case 2:  
                    animator.SetTrigger("Attack3");
                    lastAttackTime = Time.time;
                    comboState = 0; 
                    break;
                default:
                    break;
            }
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
