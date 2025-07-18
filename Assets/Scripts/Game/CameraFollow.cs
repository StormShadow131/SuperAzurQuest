using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Rigidbody2D playerRb;

    public Transform target;

    public float smoothTime = 0.2f;
    private Vector3 velocity = Vector3.zero;

    public Vector2 offset = new Vector2(0f, 1.5f);

    public Vector2 deadZoneSize = new Vector2(2f, 1f); // largeur et hauteur de la zone morte

    public float verticalLookOffset = 1f;
    public float lookDelay = 0.3f;
    private float verticalTimer = 0f;
    private float currentYOffset;

    void Start()
    {
        currentYOffset = offset.y;

        if (target != null)
        {
            playerMovement = target.GetComponent<PlayerMovement>();
        }
    }

    void Update()
    {
        HandleVerticalLookInput();
    }

    void LateUpdate()
    {
        // Calculates camera center
        Vector3 cameraCenter = transform.position - new Vector3(0f, 0f, transform.position.z);
        // Adjusts horizontal and vertical offset
        Vector3 playerPos = target.position + new Vector3(offset.x, currentYOffset, 0f);

        Vector3 difference = playerPos - cameraCenter;

        // If the player leaves the dead zone in X, we adjust the target position
        if (Mathf.Abs(difference.x) > deadZoneSize.x / 2f)
            cameraCenter.x += difference.x - Mathf.Sign(difference.x) * (deadZoneSize.x / 2f);

        // If the player leaves the dead zone in Y, we adjust the target position
        if (Mathf.Abs(difference.y) > deadZoneSize.y / 2f)
            cameraCenter.y += difference.y - Mathf.Sign(difference.y) * (deadZoneSize.y / 2f);

        Vector3 targetPosition = new Vector3(cameraCenter.x, cameraCenter.y, -10f);

        // Progressive movement of the camera with smoothing.
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    void HandleVerticalLookInput()
    {
        if (playerMovement == null)
            return;

        // Ne pas permettre de regarder haut/bas si le joueur est au sol
        if (playerMovement.isGrounded)
        {
            verticalTimer = 0f;
            currentYOffset = offset.y;
            return;
        }

        if (Input.GetAxisRaw("Vertical") > 0.1f)
        {
            verticalTimer += Time.deltaTime;
            if (verticalTimer >= lookDelay)
                currentYOffset = offset.y + verticalLookOffset;
        }
        else if (Input.GetAxisRaw("Vertical") < -0.1f)
        {
            verticalTimer += Time.deltaTime;
            if (verticalTimer >= lookDelay)
                currentYOffset = offset.y - verticalLookOffset;
        }
        else
        {
            verticalTimer = 0f;
            currentYOffset = offset.y;
        }
    }
}
