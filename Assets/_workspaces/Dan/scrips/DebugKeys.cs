using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    private Vector3 startPosition;
    private Rigidbody2D rb;

    private void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleReset();
    }

    private void HandleReset()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = startPosition;
            rb.linearVelocity = Vector2.zero;
            Debug.Log("Player position and velocity reset to starting point");
        }
    }
}
