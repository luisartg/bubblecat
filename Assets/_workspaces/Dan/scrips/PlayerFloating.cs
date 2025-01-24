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
    public float speedBreak = 0.5f;
    public float slowDownForce = 1f;
    public float sKeyPressDuration = 1f; // Duration for which the S key can be held down
    public float sKeyCooldown = 2f; // Cooldown duration after using the S key
    private float sKeyPressTimer = 0f; // Timer to track how long the S key is held down
    private float sKeyCooldownTimer = 0f; // Timer to track cooldown after using the S key
    private Rigidbody2D rb;

    private bool speedUpActive = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    private void FixedUpdate()
    {
        //ApplyFloatingForce();
        ApplyFloatingForce2();
        MovePlayer();
        CapVerticalSpeed();
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
        //rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y );
    }

    private void ApplyFloatingForce2()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * extraFloatingForce);
            speedUpActive = true;
        }
        else if (Input.GetKey(KeyCode.S) && sKeyCooldownTimer <= 0f)
        {
            if (sKeyPressTimer < sKeyPressDuration)
            {
                rb.AddForce(new Vector2(0, -baseVerticalSpeed * speedBreak));
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

        if(Input.GetKeyUp(KeyCode.S))
        {
            sKeyPressTimer = 0f;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            speedUpActive = false;
        }

        rb.AddForce(Vector2.up * baseVerticalSpeed, ForceMode2D.Force);
    }

    private void CapVerticalSpeed()
    {
        if (!speedUpActive && rb.linearVelocityY > maxVerticalSpeed)
        {
            //add a oposing force until linear velocity is inside constraints
            Debug.Log($"Applying slowdown. Current linear velocityY[{rb.linearVelocityY}]");
            rb.AddForce(Vector2.down * slowDownForce);
        }
    }

    private void MovePlayer()
    {
        //UNCOMMENT AFTER TEST
        //float moveX = Input.GetAxis("Horizontal");
        //Vector2 targetVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);
        //rb.linearVelocity = new Vector2(targetVelocity.x, rb.linearVelocity.y);
        
        MovePlayer2();//LUIS_TEST
    }

    private void MovePlayer2()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(moveX * moveSpeed, 0));
    }

    //LuisArt - TODO: Esto se puede hacer con una corutina
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

        //TODO: NOTA: Si el usuario presiona y levanta S mientras hay cooldown, el cooldown vuelve a reiniciar?
        if (Input.GetKeyUp(KeyCode.S))
        {
            sKeyCooldownTimer = sKeyCooldown;
            sKeyPressTimer = 0f;
            Debug.Log("Reset press timer");
        }
    }
}
