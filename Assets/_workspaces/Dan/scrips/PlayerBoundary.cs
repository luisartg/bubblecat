using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        ClampPositionToCamera();
    }

    private void ClampPositionToCamera()
    {
        Vector3 screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -screenBounds.x + 0.5f, screenBounds.x - 0.5f);
        transform.position = clampedPosition;
    }
}
