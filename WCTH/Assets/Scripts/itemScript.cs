using UnityEngine;
using UnityEngine.UI;
using TMPro; // Required for TextMeshPro

public class ItemScript : MonoBehaviour
{
    protected string textToDisplay; // Text to display in the TMP component
    protected Sprite imageToDisplay; // Image to display in the Image component

    protected TextMeshProUGUI tmpText; // Reference to the TMP text component
    protected Image uiImage; // Reference to the UI Image component
    protected GameObject descriptionObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        // Find the TMP text and Image components by tag if not assigned in the Inspector
        if (tmpText == null)
        {
            GameObject tmpObject = GameObject.FindWithTag("itemTxt");
            if (tmpObject != null)
            {
                tmpText = tmpObject.GetComponent<TextMeshProUGUI>();
                if (tmpText == null)
                {
                    Debug.LogWarning("No TextMeshProUGUI component found on GameObject with tag 'itemTxt'.");
                }
            }
            else
            {
               // Debug.LogWarning("No GameObject with tag 'itemTxt' found for TMP text.");
            }
        }

        if (uiImage == null)
        {
            GameObject imageObject = GameObject.FindWithTag("itemPic");
            if (imageObject != null)
            {
                uiImage = imageObject.GetComponent<Image>();
                if (uiImage == null)
                {
                    //Debug.LogWarning("No Image component found on GameObject with tag 'itemPic'.");
                }
            }
            else
            {
                //Debug.LogWarning("No GameObject with tag 'itemPic' found for UI image.");
            }
        }

        // Ensure the "itemDescription" GameObject is active at the start
        descriptionObject = GameObject.FindWithTag("itemDescription");
        if (descriptionObject != null)
        {
            descriptionObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No GameObject with tag 'itemDescription' found.");
        }
    }

    // Method to update the TMP text and UI image when a button is clicked
    public virtual void OnButtonClick()
    {
        // Turn off the GameObject with the tag "itemDescription"
        if (descriptionObject != null)
        {
            descriptionObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No GameObject with tag 'itemDescription' found.");
        }
        // Find and update the TMP text and UI image
        UpdateText();
        UpdateImage();


    }

    // Virtual method to update the TMP text
    protected virtual void UpdateText()
    {
        if (tmpText != null)
        {
            tmpText.text = textToDisplay;
        }
        else
        {
            Debug.LogWarning("TMP Text component is not assigned.");
        }
    }

    // Virtual method to update the UI image
    protected virtual void UpdateImage()
    {
        if (uiImage != null)
        {
            uiImage.sprite = imageToDisplay;
        }
        else
        {
            Debug.LogWarning("UI Image component is not assigned.");
        }
    }
}
