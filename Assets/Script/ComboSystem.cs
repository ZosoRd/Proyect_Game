using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    private Animator animator;
    private int comboState = 0; // Estado del combo actual, 0 significa que no se est� ejecutando ning�n combo
    private float lastAttackTime; // Tiempo del �ltimo ataque
    public float comboCooldown = 1f; // Cooldown entre ataques (1 segundo en este ejemplo)

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Detecta la entrada del jugador para iniciar el combo
        if (Input.GetButtonDown("Fire1")) // Ejemplo: 'Fire1' puede ser el bot�n de ataque
        {
            float timeSinceLastAttack = Time.time - lastAttackTime;

            // Si el tiempo desde el �ltimo ataque es mayor que el cooldown, reinicia el combo
            if (timeSinceLastAttack > comboCooldown)
            {
                comboState = 0;
            }

            switch (comboState)
            {
                case 0:
                    // Inicia el primer ataque
                    animator.SetTrigger("Attack1");
                    comboState = 1;
                    break;
                case 1:
                    // Inicia el segundo ataque
                    animator.SetTrigger("Attack2");
                    comboState = 2;
                    break;
                case 2:
                    // Inicia el tercer ataque
                    animator.SetTrigger("Attack3");
                    comboState = 0; // Reinicia el combo state para permitir nuevos combos
                    break;
                default:
                    // En caso de alg�n error, reinicia el estado del combo
                    comboState = 0;
                    break;
            }

            // Actualiza el tiempo del �ltimo ataque
            lastAttackTime = Time.time;
        }
    }
}
