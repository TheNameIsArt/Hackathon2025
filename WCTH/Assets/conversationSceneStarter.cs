using UnityEngine;
using DialogueEditor;

public class conversationSceneStarter : MonoBehaviour
{
    public NPCConversation Conversation; // Reference to the conversation asset
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ConversationManager.Instance.StartConversation(Conversation);
    }
}
