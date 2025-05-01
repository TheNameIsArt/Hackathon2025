using UnityEngine;
using UnityEngine.UI;
using TMPro; // Required for TextMeshPro

public class ItemScript : MonoBehaviour
{
    [SerializeField] private string textToDisplay; // Text to display in the TMP component
    [SerializeField] private Sprite imageToDisplay; // Image to display in the Image component

    [SerializeField] private TextMeshProUGUI tmpText; // Reference to the TMP text component
    [SerializeField] private Image uiImage; // Reference to the UI Image component
    [SerializeField] private GameObject descriptionObject; // Reference to the description GameObject

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        // Ensure the "itemDescription" GameObject is inactive at the start
        if (descriptionObject != null)
        {
            descriptionObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning($"Description object is not assigned in {gameObject.name}.");
        }
    }

    // Method to update the TMP text and UI image when a button is clicked
    public void OnButtonClick()
    {
        // Activate the description object
        if (descriptionObject != null)
        {
            descriptionObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning($"Description object is not assigned in {gameObject.name}.");
        }

        // Update the TMP text and UI image
        UpdateText();
        UpdateImage();
    }

    // Method to update the TMP text
    private void UpdateText()
    {
        if (tmpText != null)
        {
            tmpText.text = textToDisplay;
        }
        else
        {
            Debug.LogWarning($"TMP Text component is not assigned in {gameObject.name}.");
        }
    }

    // Method to update the UI image
    private void UpdateImage()
    {
        if (uiImage != null)
        {
            uiImage.sprite = imageToDisplay;
        }
        else
        {
            Debug.LogWarning($"UI Image component is not assigned in {gameObject.name}.");
        }
    }
}
