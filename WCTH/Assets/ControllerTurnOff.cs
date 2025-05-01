using UnityEngine;
using DialogueEditor;
public class ControllerTurnOff : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ConversationManager.Instance != null)
        {
            if (ConversationManager.Instance.IsConversationActive == true)
            {
                // Disable all child objects
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(false);
                }
            }
            else
            {
                // Enable all child objects
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
    }
}
