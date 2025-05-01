using UnityEngine;

public class DisableAsteroid : MonoBehaviour
{
    public CarlsMinigameManager carlsMinigameManager;
    private float deadZoneXValueLeft = -12f;
    private float deadZoneXValueRight = 12f;
    private float deadZoneYValueTop = 6f;
    private float deadZoneYValueBottom = -6f;

    void Update()
    {
        if (transform.position.x < deadZoneXValueLeft || transform.position.x > deadZoneXValueRight ||transform.position.y > deadZoneYValueTop || transform.position.y < deadZoneYValueBottom) //Checks if the asteroids hits any of the positions given at the top. If it does, it is set as false, pooling it back.
        {
            gameObject.SetActive(false);
        }
    }
}
