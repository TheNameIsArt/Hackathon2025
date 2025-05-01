using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CustomItemScript : MonoBehaviour
{
    [SerializeField] private Sprite itemImage; // The sprite to set
    [SerializeField] private string itemDescription; // The description to set
    [SerializeField] private Image targetImage; // The target Image component to update
    [SerializeField] private TextMeshProUGUI targetText; // The target TMP text component to update
    [SerializeField] private GameObject targetGameObject;

    // Method to update the target Image and TMP text
    public void OnButtonClick()
    {
        // Update the target Image's sprite
        if (targetImage != null)
        {
            targetImage.sprite = itemImage;
        }
        else
        {
            Debug.LogWarning($"Target Image is not assigned in {gameObject.name}.");
        }

        // Update the target TMP text's content
        if (targetText != null)
        {
            targetText.text = itemDescription;
        }
        else
        {
            Debug.LogWarning($"Target TextMeshProUGUI is not assigned in {gameObject.name}.");
        }
        targetGameObject.SetActive(true);
    }
}
