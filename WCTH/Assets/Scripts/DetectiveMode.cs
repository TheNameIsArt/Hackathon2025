using UnityEngine;

public class DetectiveMode : MonoBehaviour
{
    public GameObject button1;

    void Update()
    {
        // Get the accelerometer data
        Vector3 acceleration = Input.acceleration;

        // Check if the phone is in portrait mode (upright)
        if (Mathf.Abs(acceleration.x) < Mathf.Abs(acceleration.y))
        {
            button1.SetActive(false);
            Debug.Log("Phone is in portrait mode (upright). Button is visible.");
        }
        else
        {
            button1.SetActive(true);
            Debug.Log("Phone is in landscape mode (horizontal). Button is hidden.");
        }
    }
}