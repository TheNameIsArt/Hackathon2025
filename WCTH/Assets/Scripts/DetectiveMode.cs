using UnityEngine;

public class DetectiveMode : MonoBehaviour
{
    public GameObject button1; // Reference to the button
    public RectTransform imageToMove; // Reference to the image to move
    public float moveSpeed = 1000f; // Speed of movement
    public float smoothing = 0.1f; // Smoothing factor for movement
    public float maxVerticalMovement = 500f; // Maximum vertical movement range
    public float flatThreshold = 0.8f; // Threshold for detecting if the phone is flat

    private bool isGyroEnabled = false;
    private Vector2 smoothedPosition = Vector2.zero;
    public Canvas controlCanvas; // Reference to the control canvas

    void Start()
    {
        // Enable the gyroscope if supported
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
            isGyroEnabled = true;
        }
        else
        {
            Debug.LogWarning("Gyroscope not supported on this device.");
        }
    }

    void Update()
    {
        // Get the accelerometer data
        Vector3 acceleration = Input.acceleration;

        // Check if the phone is flat (z-axis close to -1)
        if (Mathf.Abs(acceleration.z) > flatThreshold)
        {
            return; // Ignore mode switching if the phone is flat
        }

        // Check if the phone is in portrait mode (upright)
        if (Mathf.Abs(acceleration.x) < Mathf.Abs(acceleration.y))
        {
            button1.SetActive(false);
            controlCanvas.enabled = true; // Enable the control canvas
        }
        else
        {
            button1.SetActive(true);
            controlCanvas.enabled = false; // Disable the control canvas

            if (isGyroEnabled && imageToMove != null)
            {
                // Use the gyroscope's rotation rate for vertical movement (inverted)
                float verticalMovement = -Input.gyro.rotationRateUnbiased.x * moveSpeed * Time.deltaTime;

                // Apply smoothing to the movement
                smoothedPosition = Vector2.Lerp(smoothedPosition, new Vector2(0, verticalMovement), smoothing);

                // Update the image's position, clamping it within the allowed range
                Vector2 newPosition = imageToMove.anchoredPosition + smoothedPosition;
                newPosition.y = Mathf.Clamp(newPosition.y, -maxVerticalMovement, maxVerticalMovement);
                imageToMove.anchoredPosition = newPosition;
            }
        }
    }
}
