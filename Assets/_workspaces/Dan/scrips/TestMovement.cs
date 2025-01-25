using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    public enum MovementType { SineWave, Spiral, Circular, UpDown, Horizontal, Random }
    public enum Direction { Left, Right }

    public MovementType movementType = MovementType.SineWave;
    public Direction direction = Direction.Left;

    public float moveSpeed = 0.25f; // Speed at which the plane moves
    public float amplitude = 0.3f; // Amplitude of the sine wave
    public float frequency = 0.8f; // Frequency of the sine wave
    public float k = 0.1f; // Constant for spiral movement
    public float circleRadius = 1f; // Radius for circular movement

    private float startY;
    private float time; // Time variable for all movements
    private Vector2 lastPosition; // Store the last position for smooth transitions

    void Start()
    {
        startY = transform.position.y; // Store the initial Y position
        lastPosition = transform.position; // Initialize lastPosition
        time = 0f; // Initialize time
    }

    void FixedUpdate()
    {
        switch (movementType)
        {
            case MovementType.SineWave:
                ApplySineWaveMovement();
                break;
            case MovementType.Spiral:
                ApplySpiralMovement();
                break;
            case MovementType.Circular:
                ApplyCircularMovement();
                break;
            case MovementType.UpDown:
                ApplyUpDownMovement();
                break;
            case MovementType.Horizontal:
                ApplyHorizontalMovement();
                break;
            case MovementType.Random:
                ApplyRandomMovement();
                break;        
        }
    }

    void ApplySineWaveMovement()
    {
        // Calculate the new Y position using a sine wave
        float newY = startY + Mathf.Sin(Time.time * frequency) * amplitude;
        float dir = direction == Direction.Left ? -1 : 1;

        // Update the position
        transform.position = new Vector2(transform.position.x + moveSpeed * dir * Time.deltaTime, newY);

        // Update lastPosition
        lastPosition = transform.position;
    }

    void ApplySpiralMovement()
    {
        // Increment time
        time += Time.deltaTime;

        // Calculate the new position for the spiral
        float x = (k * time) * Mathf.Cos(time);
        float y = (k * time) * Mathf.Sin(time);
        Vector2 spiralPosition = new Vector2(x, y);


        // Update the position
        transform.position = new Vector2(spiralPosition.x, spiralPosition.y);

        // Update lastPosition
        lastPosition = transform.position;
    }

    void ApplyCircularMovement()
    {
        // Increment time
        time += Time.deltaTime;

        // Calculate the new position for the circle
        float x = circleRadius * Mathf.Cos(time);
        float y = circleRadius * Mathf.Sin(time);
        Vector2 circularPosition = new Vector2(x, y);
        

        // Update the position
        transform.position = new Vector2(circularPosition.x , circularPosition.y);

        // Update lastPosition
        lastPosition = transform.position;
    }

    void ApplyUpDownMovement()
    {
        // Increment time
        time += Time.deltaTime;

        // Calculate the new Y position using a sine wave
        float newY = startY + Mathf.Sin(time * frequency) * amplitude;

        // Update the position
        transform.position = new Vector2(transform.position.x, newY);

        // Update lastPosition
        lastPosition = transform.position;
    }

    void ApplyHorizontalMovement()
    {
        float dir = direction == Direction.Left ? -1 : 1;

        // Update the position
        transform.position = new Vector2(transform.position.x + moveSpeed * dir * Time.deltaTime, transform.position.y);

        // Update lastPosition
        lastPosition = transform.position;
    }

  
    void ApplyRandomMovement()
    {
        // Generate random direction for x and y
        float randomX = Random.Range(-5f, 5f) * moveSpeed * Time.deltaTime;
        float randomY = Random.Range(-5f, 5f) * moveSpeed * Time.deltaTime;

        // Update the position
        transform.position = new Vector2(transform.position.x + randomX, transform.position.y + randomY);

        // Update lastPosition
        lastPosition = transform.position;
    }

    
}
