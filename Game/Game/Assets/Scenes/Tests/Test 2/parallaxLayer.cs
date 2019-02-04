using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxLayer : MonoBehaviour
{
    public float speedX;
    public float speedY;
    public bool moveInOppositeDirection;

    private Transform cameraTransform;
    private Vector3 previousCameraPosition;
    private bool previousMoveParallax;
    private parallaxOption options;

    void OnEnable()
    {
        GameObject gameCamera = GameObject.Find("Main Camera");
        options = gameCamera.GetComponent<parallaxOption>();
        cameraTransform = gameCamera.transform;
        previousCameraPosition = cameraTransform.position;
    }

    void FixedUpdate()
    {
        if (options.moveParallax && !previousMoveParallax)
            previousCameraPosition = cameraTransform.position;

        previousMoveParallax = options.moveParallax;

        if (!Application.isPlaying && !options.moveParallax)
            return;

        Vector3 distance = cameraTransform.position - previousCameraPosition;
        float direction = (moveInOppositeDirection) ? -1f : 1f;
        transform.position += Vector3.Scale(distance, new Vector3(speedX, speedY)) * direction;

        previousCameraPosition = cameraTransform.position;
    }
}
