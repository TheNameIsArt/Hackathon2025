using UnityEngine;
using UnityEngine.UI;

public class PictureCyclerFromObjects : MonoBehaviour
{
    public Image targetImage; // UI Image to show the sprite on (for UI)
    // public SpriteRenderer targetRenderer; // Use this instead if you're using SpriteRenderer

    public GameObject[] sourceObjects; // Assign 3 objects with Sprites (e.g., UI Images or SpriteRenderers)

    private Sprite[] pictures;
    private int currentIndex = 0;

    void Start()
    {
        // Load sprites from assigned objects
        pictures = new Sprite[sourceObjects.Length];
        for (int i = 0; i < sourceObjects.Length; i++)
        {
            var spriteRenderer = sourceObjects[i].GetComponent<SpriteRenderer>();
            var image = sourceObjects[i].GetComponent<Image>();

            if (spriteRenderer != null)
                pictures[i] = spriteRenderer.sprite;
            else if (image != null)
                pictures[i] = image.sprite;
            else
                Debug.LogWarning("Object " + sourceObjects[i].name + " has no SpriteRenderer or Image.");
        }

        ShowCurrentPicture();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowNextPicture();
        }
    }

    public void ShowCurrentPicture()
    {
        if (pictures[currentIndex] != null)
            targetImage.sprite = pictures[currentIndex];
        // targetRenderer.sprite = pictures[currentIndex]; // Use if using SpriteRenderer
    }

    public void ShowNextPicture()
    {
        currentIndex = (currentIndex + 1) % pictures.Length;
        ShowCurrentPicture();
    }
}