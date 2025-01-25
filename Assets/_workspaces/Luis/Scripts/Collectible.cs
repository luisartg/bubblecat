using System;
using System.Collections;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collectible Triggered");
        if (collision.gameObject.CompareTag("Player"))
        {
            AddCollectible();
        }
    }

    private void AddCollectible()
    {
        //Add to count - TODO
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<ParticleSystem>().Play();
        StartCoroutine(KillAfterSeconds());
    }

    private IEnumerator KillAfterSeconds()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
