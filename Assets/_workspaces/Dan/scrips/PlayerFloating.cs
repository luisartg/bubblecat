using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFloating : MonoBehaviour
{
    public float baseVerticalSpeed = 1f;
    public float maxVerticalSpeed = 10f;
    public float extraFloatingForce = 5f;
    public float reducedFloatingForce = -5f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ApplyFloatingForce();
        CapVerticalSpeed();
    }

    private void ApplyFloatingForce()
    {
        float currentFloatingForce = baseVerticalSpeed;
        if (Input.GetKey(KeyCode.W))
        {
            currentFloatingForce += extraFloatingForce;
            rb.AddForce(Vector2.up * currentFloatingForce, ForceMode2D.Impulse);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            float newVerticalSpeed = Mathf.Max(0, rb.linearVelocity.y + reducedFloatingForce);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, newVerticalSpeed);
        }
        else
        {
            rb.AddForce(Vector2.up * currentFloatingForce, ForceMode2D.Impulse);
        }
    }

    private void CapVerticalSpeed()
    {
        float clampY = Mathf.Clamp(rb.linearVelocity.y, 0, maxVerticalSpeed);
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, clampY);
    }
}
