using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float smoothSpeed = 0.125f; // Adjust this value to change the smoothness of the camera movement
    public Vector3 offset; // Offset between the camera and the player
    public float addOffsetPerSecond = 0.1f;
    public bool useOffsetOverTime = false;

    private float currentAccumulatedOffset = 0;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, player.position.y + offset.y, transform.position.z);
        if (useOffsetOverTime)
        {
            StartCoroutine(AddOffset());
        }
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(
            transform.position.x, 
            player.position.y + offset.y + currentAccumulatedOffset, 
            transform.position.z);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    private IEnumerator AddOffset()
    {
        yield return new WaitForSeconds(1);
        currentAccumulatedOffset += addOffsetPerSecond;
        StartCoroutine(AddOffset());
    }
}
