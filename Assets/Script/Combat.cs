using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;

    public float attackCooldown = 1f; 
    private float lastAttackTime;

    public int attackDamage = 40;


    private int comboState = 0; 

    public float maxComboDelay = 1.5f;
    private float comboTimer;

    void Update()
    {
        comboTimer += Time.deltaTime;

        if (comboTimer >= maxComboDelay)
        {
            comboState = 0;
            comboTimer = 0f;
        }
        
        if (Input.GetKeyDown(KeyCode.Z))
            {
            if (Time.time - lastAttackTime >= attackCooldown)
                {
                    Attack();
                    lastAttackTime = Time.time; 
                    comboTimer = 0f;
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
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
