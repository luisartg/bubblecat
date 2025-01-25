using System.Collections;
using UnityEngine;

public class WindForceEffect : MonoBehaviour
{
    public float WindForce = 1f;
    [SerializeField]
    private Vector2 windDirection = Vector2.up;
    private bool activeEffect = false;
    private Rigidbody2D playerRb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float currentAngle = gameObject.transform.rotation.eulerAngles.z + 90;
        float sin = Mathf.Sin(currentAngle * Mathf.Deg2Rad);
        float cos = Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        windDirection = new Vector2(cos, sin);
    }

    private IEnumerator ApplyContinuousForce()
    {
        if (activeEffect)
        {
            playerRb.AddForce(windDirection.normalized * WindForce);
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
