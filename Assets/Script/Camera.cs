using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Referencia al transform del objeto que seguir� la c�mara
    public Vector3 offset = new Vector3(0f, 0f, -10f);  // Offset de la c�mara respecto al objetivo
    public float smoothTime = 0.3f;  // Tiempo de suavizado de la c�mara

    private Vector3 velocity = Vector3.zero;  // Velocidad actual de la interpolaci�n

    void Update()
    {
        if (target != null)
        {
            // Calcular la posici�n deseada de la c�mara
            Vector3 desiredPosition = target.position + offset;

            // Calcular suavemente la posici�n de la c�mara usando SmoothDamp
            Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);

            // Aplicar la nueva posici�n a la c�mara
            transform.position = smoothPosition;
        }
    }
}

