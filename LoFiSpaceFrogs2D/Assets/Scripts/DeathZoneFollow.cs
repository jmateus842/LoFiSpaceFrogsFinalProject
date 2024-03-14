using UnityEngine;

public class DeathZoneFollow : MonoBehaviour
{
    private Transform mainCameraTransform;

    void Start()
    {
        // Find the Main Camera by tag
        mainCameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;

        // Ensure that the Main Camera is found
        if (mainCameraTransform == null)
        {
            Debug.LogError("Main Camera not found. Make sure it is tagged as 'MainCamera'.");
        }
    }

    void Update()
    {
        // Ensure that the Main Camera is found before updating the Death Zone's position
        if (mainCameraTransform != null)
        {
            // Keep the Death Zone's y position constant and follow the Main Camera's x position
            Vector3 newPosition = transform.position;
            newPosition.x = mainCameraTransform.position.x;
            transform.position = newPosition;
        }
    }
}
