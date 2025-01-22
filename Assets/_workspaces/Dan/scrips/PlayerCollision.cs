using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    
    private float collisionTime;
    private PlayerHealth playerHealth;

    private void Start()
    {
        
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            Debug.Log("Stopping collision with wall");
            collisionTime = 0f;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            collisionTime += Time.deltaTime;
            Debug.Log("Timer: " + collisionTime);
            if (collisionTime >= 3f)
            {
                Debug.Log("Player died after colliding for 3 seconds");
                playerHealth.Die();
                collisionTime = 0f;
            }
        }
    }
}
