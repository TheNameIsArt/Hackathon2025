using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    // This method will be triggered when entering a circle collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider has a specific tag (optional)
        if (other.CompareTag("YourTagHere"))
        {
            ConversationStart();
        }
    }

    // The method to be triggered
    private void ConversationStart()
    {
        Debug.Log("Entered the circle collider!");
        // Add your custom logic here
    }
}
