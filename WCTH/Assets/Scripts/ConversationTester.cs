using DialogueEditor;
using UnityEngine;

public class ConversationTester : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public NPCConversation conversation;
    void Start()
    {
        ConversationManager.Instance.StartConversation(conversation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
