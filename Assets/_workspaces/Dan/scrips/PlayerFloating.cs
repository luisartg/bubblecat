using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFloating : MonoBehaviour
{
    public float baseVerticalSpeed = 1f;
    public float maxVerticalSpeed = 10f;
    public float extraFloatingForce = 5f;
    public float reducedFloatingForce = -5f;
    public float moveSpeed = 5f;
    public float sKeyPressDuration = 1f; // Duration for which the S key can be held down
    public float sKeyCooldown = 2f; // Cooldown duration after using the S key
    private float sKeyPressTimer = 0f; // Timer to track how long the S key is held down
    private float sKeyCooldownTimer = 0f; // Timer to track cooldown after using the S key
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    private void FixedUpdate()
    {
        ApplyFloatingForce();
        MovePlayer();
       /* CapVerticalSpeed();*/
        UpdateCooldowns();
    }

    private void ApplyFloatingForce()
    {
        float currentFloatingForce = baseVerticalSpeed;
        if (Input.GetKey(KeyCode.W))
        {
            currentFloatingForce += extraFloatingForce;
            rb.AddForce(Vector2.up * currentFloatingForce, ForceMode2D.Force);
        }
        else if (Input.GetKey(KeyCode.S) && sKeyCooldownTimer <= 0f)
        {
            if (sKeyPressTimer < sKeyPressDuration)
            {
                float newVerticalSpeed = Mathf.Max(0, rb.linearVelocity.y + reducedFloatingForce);
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, newVerticalSpeed);
                sKeyPressTimer += Time.fixedDeltaTime;
                Debug.Log("s key timer : " + sKeyPressTimer);
            }
            else
            {
                sKeyCooldownTimer = sKeyCooldown;
                sKeyPressTimer = 0f; 
                Debug.Log("Reset press timer");
            }
        }
        else
        {
            rb.AddForce(Vector2.up * currentFloatingForce, ForceMode2D.Force);
            sKeyPressTimer = 0f;
        }

        // ?
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y );
    }

    private void CapVerticalSpeed()
    {
        float clampY = Mathf.Clamp(rb.linearVelocity.y, 0, maxVerticalSpeed);
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, clampY);
    }

    private void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        Vector2 targetVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);
        rb.linearVelocity = new Vector2(targetVelocity.x, rb.linearVelocity.y);
    }

    private void UpdateCooldowns()
    {
        if (sKeyCooldownTimer > 0f)
        {
            sKeyCooldownTimer -= Time.fixedDeltaTime;
        }
        else if (sKeyCooldownTimer < 0f)
        {
            sKeyCooldownTimer = 0f; // Ensure the cooldown timer doesnt go negative
        }

        
        if (Input.GetKeyUp(KeyCode.S))
        {
            sKeyCooldownTimer = sKeyCooldown;
            sKeyPressTimer = 0f;
            Debug.Log("Reset press timer");
        }
    }
}
