using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcFlip : MonoBehaviour
{
    private Transform player;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;

            if (direction.x < 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (direction.x > 0)
            {
                spriteRenderer.flipX = true;
            }
        }
    }
}