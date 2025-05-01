using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{
    public Image[] images; // Array to hold the different images
    private int currentImageIndex = 0;
    private bool playerInZone = false;

    void Start()
    {
        // Ensure only the first image is active at the start
        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player entered the trigger zone
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player exited the trigger zone
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
        }
    }

    void Update()
    {
        // Check if the player is in the zone and presses the "E" key
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            SwitchImage();
        }
    }

    public void SwitchImage()
    {
        // Deactivate the current image
        images[currentImageIndex].gameObject.SetActive(false);

        // Move to the next image
        currentImageIndex = (currentImageIndex + 1) % images.Length;

        // Activate the new image
        images[currentImageIndex].gameObject.SetActive(true);
    }
}
