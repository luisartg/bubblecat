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
   
    private Rigidbody2D rb;

    [SerializeField]
    private BCatAnimation catAnim;

    private bool speedUpActive = false;
    private bool isCooldownActive = false;
    private bool isSlowingDown = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        catAnim = GetComponentInChildren<BCatAnimation>();
    }

    private void FixedUpdate()
    {
        
        ApplyFloatingForce2();
        MovePlayer();
        CapVerticalSpeed();
      
    }



    private void ApplyFloatingForce2()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * extraFloatingForce);
            speedUpActive = true;
        }
        // Slowing down when pressing S
        if (Input.GetKey(KeyCode.S) && !isCooldownActive)
        {
            if (!isSlowingDown) 
            {
                isSlowingDown = true;
                StartCoroutine(SlowDown());
            }
        }
        else
        {
            
            sKeyPressTimer = 0f;
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

        //Animation
        if (moveX > 0)
        {
            catAnim.GoRight();
        }
        else if (moveX < 0)
        {
            catAnim.GoLeft();
        }
        else
        {
            catAnim.Idle();
        }
    }

    private IEnumerator SlowDown()
    {
        // Apply slow down force for the duration of the key press
        while (Input.GetKey(KeyCode.S) && sKeyPressTimer < sKeyPressDuration)
        {
            rb.AddForce(new Vector2(0, -baseVerticalSpeed * speedBreak));
            sKeyPressTimer += Time.fixedDeltaTime;
            Debug.Log("s key timer: " + sKeyPressTimer);
            yield return new WaitForFixedUpdate();
        }

        // Start cooldown
        Debug.Log("start cooldown");
        isCooldownActive = true;
        sKeyPressTimer = 0f;
        isSlowingDown = false;

        // Wait for cooldown duration
        yield return new WaitForSeconds(sKeyCooldown);
        isCooldownActive = false;
        Debug.Log("finished cooldown");
    }

}
