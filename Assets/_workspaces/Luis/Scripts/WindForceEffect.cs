using System.Collections;
using UnityEngine;

public class WindForceEffect : MonoBehaviour
{
    public Vector2 WindDirection = Vector2.up;
    public float WindForce = 1f;
    private bool activeEffect = false;
    private Rigidbody2D playerRb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private IEnumerator ApplyContinuousForce()
    {
        if (activeEffect)
        {
            playerRb.AddForce(WindDirection.normalized * WindForce);
            yield return new WaitForFixedUpdate();
            StartCoroutine(ApplyContinuousForce());
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            activeEffect = true;
            StartCoroutine(ApplyContinuousForce());
            Debug.Log("Started Wind Effect");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        activeEffect = false;
        Debug.Log("Ended Wind Effect");
    }
}
