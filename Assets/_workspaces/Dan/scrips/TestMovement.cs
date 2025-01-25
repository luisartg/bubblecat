using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    public enum MovementType { None, SineWave, Spiral, Circular, UpDown, Horizontal, Random, Diagonal, GetCloseToPlayer, GetFarFromPlayer }
    public enum Direction { Left, Right }
    public enum DiagonalDirection { UpRight, UpLeft, DownRight, DownLeft }

    public MovementType movementType = MovementType.None;
    public Direction direction = Direction.Left;
    public DiagonalDirection diagonalDirection = DiagonalDirection.UpRight;

    [Range(0f, 5f)]
    public float moveSpeed = 0.25f; // Speed 

    [Range(0f, 1f)]
    public float amplitude = 0.3f; // Amplitude

    [Range(0f, 2f)]
    public float frequency = 0.8f; // Frequency

    [Range (0f, 1f)]
    public float k = 0.1f; // Constant for spiral movement

    [Range (0f, 8f)]
    public float circleRadius = 1f; // Radius for circular movement

    [Range(0f, 10f)]
    public float randomXRange = 5f;

    [Range(0f, 10f)]
    public float randomYRange = 5f; 

    public Transform player; 

    private float startY;
    private float time; 
    private Vector2 lastPosition; 
    private Transform cachedTransform;

    void Start()
    {
        cachedTransform = transform; 
        startY = cachedTransform.position.y; 
        lastPosition = cachedTransform.position; 
        time = 0f; 
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;

        switch (movementType)
        {
            case MovementType.None:
                // Do nothing
                break;
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
            case MovementType.Diagonal:
                ApplyDiagonalMovement();
                break;
            case MovementType.GetCloseToPlayer:
                ApplyPlayerInteractionMovement(true);
                break;
            case MovementType.GetFarFromPlayer:
                ApplyPlayerInteractionMovement(false);
                break;
        }
    }

    void ApplySineWaveMovement()
    {
        // Calculate the new Y position using a sine wave
        float newY = startY + Mathf.Sin(time * frequency) * amplitude;
        float dir = direction == Direction.Left ? -1 : 1;

        // Update the position
        cachedTransform.position = new Vector2(cachedTransform.position.x + moveSpeed * dir * Time.deltaTime, newY);

        // Update lastPosition
        lastPosition = cachedTransform.position;
    }

    void ApplySpiralMovement()
    {
        // Calculate the new position for the spiral
        float x = (k * time) * Mathf.Cos(time);
        float y = (k * time) * Mathf.Sin(time);
        Vector2 spiralPosition = new Vector2(x, y);

        // Update the position
        cachedTransform.position = new Vector2(spiralPosition.x, spiralPosition.y);

        // Update lastPosition
        lastPosition = cachedTransform.position;
    }

    void ApplyCircularMovement()
    {
        // Calculate the new position for the circle
        float x = circleRadius * Mathf.Cos(time);
        float y = circleRadius * Mathf.Sin(time);
        Vector2 circularPosition = new Vector2(x, y);

        // Update the position
        cachedTransform.position = new Vector2(circularPosition.x, circularPosition.y);

        // Update lastPosition
        lastPosition = cachedTransform.position;
    }

    void ApplyUpDownMovement()
    {
        // Calculate the new Y position using a sine wave
        float newY = startY + Mathf.Sin(time * frequency) * amplitude;

        // Update the position
        cachedTransform.position = new Vector2(cachedTransform.position.x, newY);

        // Update lastPosition
        lastPosition = cachedTransform.position;
    }

    void ApplyHorizontalMovement()
    {
        float dir = direction == Direction.Left ? -1 : 1;

        // Update the position
        cachedTransform.position = new Vector2(cachedTransform.position.x + moveSpeed * dir * Time.deltaTime, cachedTransform.position.y);

        // Update lastPosition
        lastPosition = cachedTransform.position;
    }

    void ApplyRandomMovement()
    {
        // Generate random direction for x and y
        float randomX = Random.Range(-randomXRange, randomXRange) * moveSpeed * Time.deltaTime;
        float randomY = Random.Range(-randomYRange, randomYRange) * moveSpeed * Time.deltaTime;

        // Update the position
        cachedTransform.position = new Vector2(cachedTransform.position.x + randomX, cachedTransform.position.y + randomY);

        // Update lastPosition
        lastPosition = cachedTransform.position;
    }

    void ApplyDiagonalMovement()
    {
        float dirX = 0f;
        float dirY = 0f;

        switch (diagonalDirection)
        {
            case DiagonalDirection.UpRight:
                dirX = 1;
                dirY = 1;
                break;
            case DiagonalDirection.UpLeft:
                dirX = -1;
                dirY = 1;
                break;
            case DiagonalDirection.DownRight:
                dirX = 1;
                dirY = -1;
                break;
            case DiagonalDirection.DownLeft:
                dirX = -1;
                dirY = -1;
                break;
        }

        // Update the position diagonally
        cachedTransform.position = new Vector2(cachedTransform.position.x + moveSpeed * dirX * Time.deltaTime, cachedTransform.position.y + moveSpeed * dirY * Time.deltaTime);

        // Update lastPosition
        lastPosition = cachedTransform.position;
    }

    void ApplyPlayerInteractionMovement(bool getClose)
    {
        if (player != null)
        {
            Vector2 directionToPlayer = (player.position - cachedTransform.position).normalized;
            Vector2 directionAwayFromPlayer = (cachedTransform.position - player.position).normalized;

            // Move towards or away from the player based on the flag
            if (getClose)
            {
                cachedTransform.position = Vector2.MoveTowards(cachedTransform.position, player.position, moveSpeed * Time.deltaTime);
            }
            else
            {
                cachedTransform.position += (Vector3)(directionAwayFromPlayer * moveSpeed * Time.deltaTime);
            }

            // Update lastPosition
            lastPosition = cachedTransform.position;
        }
    }
}
