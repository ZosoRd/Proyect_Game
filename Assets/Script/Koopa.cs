using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koopa : MonoBehaviour
{
    public float speed = 2f; // Velocidad de movimiento del enemigo
    public LayerMask groundLayer; // Capa que representa el suelo o las plataformas
    public float checkRadius = 0.2f; // Radio para verificar el suelo
    public Transform groundCheck; // Transform para verificar el suelo
    public bool isFacingRight = true; // Indica si el enemigo est� mirando hacia la derecha inicialmente

    private Rigidbody2D rb;
    private bool isGrounded = false; // Indica si el enemigo est� en el suelo
    private bool isTouchingWall = false; // Indica si el enemigo est� tocando una pared
    private Vector2 movementDirection; // Direcci�n de movimiento del enemigo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementDirection = isFacingRight ? Vector2.right : Vector2.left; // Inicializar la direcci�n de movimiento
    }

    void Update()
    {
        // Verificar si el enemigo est� en el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // Verificar si el enemigo est� tocando una pared
        isTouchingWall = Physics2D.Raycast(transform.position, movementDirection, 0.5f, groundLayer);

        // Si el enemigo no est� en el suelo o toca una pared, cambiar de direcci�n
        if (!isGrounded || isTouchingWall)
        {
            ChangeDirection();
        }

        // Aplicar movimiento
        rb.velocity = movementDirection * speed;
    }

    void ChangeDirection()
    {
        // Cambiar la direcci�n de movimiento y voltear el sprite
        movementDirection = movementDirection == Vector2.right ? Vector2.left : Vector2.right;
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(isFacingRight ? 1 : -1, 1, 1); // Voltear el sprite en el eje X
    }

    void OnDrawGizmosSelected()
    {
        // Dibujar un c�rculo para mostrar el �rea de verificaci�n del suelo
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}