using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Referencia al transform del objeto que seguirá la cámara
    public Vector3 offset = new Vector3(0f, 0f, -10f);  // Offset de la cámara respecto al objetivo
    public float smoothTime = 0.3f;  // Tiempo de suavizado de la cámara

    private Vector3 velocity = Vector3.zero;  // Velocidad actual de la interpolación

    void Update()
    {
        if (target != null)
        {
            // Calcular la posición deseada de la cámara
            Vector3 desiredPosition = target.position + offset;

            // Calcular suavemente la posición de la cámara usando SmoothDamp
            Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);

            // Aplicar la nueva posición a la cámara
            transform.position = smoothPosition;
        }
    }
}

