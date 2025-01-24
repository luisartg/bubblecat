using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovementLeft : MonoBehaviour
{
    public float moveSpeed = 0.25f; // Speed at which the plane moves horizontally
    public float amplitude = 0.3f; // Amplitude of the sine wave (how far up and down it goes)
    public float frequency = 0.8f; // Frequency of the sine wave (how fast it oscillates)
    private Rigidbody2D rb;
    private float startY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startY = transform.position.y; // Store the initial Y position
    }

    void FixedUpdate()
    {
        // Calculate the new Y position using a sine wave
        float newY = startY + Mathf.Sin(Time.time * frequency) * amplitude;

        // Apply force to move the plane to the left and up/down
        rb.AddForce(new Vector2(-moveSpeed, newY - transform.position.y));
    }
}
