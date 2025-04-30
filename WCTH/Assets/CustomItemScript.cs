using UnityEngine;
public class CustomItemScript : ItemScript
{
    [SerializeField] private string customName; // Custom name for this item
    [SerializeField] private Sprite customImage; // Custom image for this item

    // Override the OnButtonClick method to change only the name and image
    public override void OnButtonClick()
    {
        // Set the custom name and image
        textToDisplay = customName;
        imageToDisplay = customImage;

        // Call the base implementation to update the TMP text and UI image
        base.OnButtonClick();
    }
}
