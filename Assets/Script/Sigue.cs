using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sigue : MonoBehaviour
{
    public float speed = 2f; // Velocidad de movimiento del enemigo
    public LayerMask groundLayer; // Capa que representa el suelo o las plataformas
    public float checkRadius = 0.2f; // Radio para verificar el suelo
    public Transform groundCheck; // Transform para verificar el suelo
    public bool isFacingRight = true; // Indica si el enemigo est� mirando hacia la derecha inicialmente

    private Rigidbody2D rb;
    private bool isGrounded = false; // Indica si el enemigo est� en el suelo
    private Transform player; // Referencia al transform del jugador

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Buscar el transform del jugador (asume que el jugador tiene un tag "Player")
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Verificar si el enemigo est� en el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // Calcular la direcci�n hacia el jugador si ambos est�n en el suelo
        if (isGrounded)
        {
            Vector2 directionToPlayer = player.position - transform.position;
            directionToPlayer = new Vector2(directionToPlayer.x, 0f).normalized; // Limitar al eje X
            rb.velocity = directionToPlayer * speed;

            // Voltear el sprite seg�n la direcci�n de movimiento
            if (directionToPlayer.x > 0 && !isFacingRight || directionToPlayer.x < 0 && isFacingRight)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        // Voltear el sprite del enemigo
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(isFacingRight ? 1 : -1, 1, 1);
    }

    void OnDrawGizmosSelected()
    {
        // Dibujar un c�rculo para mostrar el �rea de verificaci�n del suelo
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}

