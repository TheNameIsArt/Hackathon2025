using UnityEngine;

public class DisableAsteroid : MonoBehaviour
{
    private float deadZone = -12f; // Adjust based on your screen/camera

    void Update()
    {
        if (transform.position.x < deadZone)
        {
            gameObject.SetActive(false);
        }
    }
}
