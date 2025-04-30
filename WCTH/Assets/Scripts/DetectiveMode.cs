using UnityEngine;
using UnityEngine.UI;

public class DetectiveMode : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;

    private ScreenOrientation lastOrientation;

    void Start()
    {
        // Initialize the last orientation
        lastOrientation = Screen.orientation;

        // Ensure buttons are initially hidden
        button1.SetActive(false);
        button2.SetActive(false);
    }

    void Update()
    {
        // Check if the screen orientation has changed
        if (Screen.orientation != lastOrientation)
        {
            lastOrientation = Screen.orientation;

            if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
            {
                // Show buttons when in portrait mode
                button1.SetActive(true);
                button2.SetActive(true);
            }
            else
            {
                // Hide buttons in other orientations
                button1.SetActive(false);
                button2.SetActive(false);
            }
        }
    }
}
