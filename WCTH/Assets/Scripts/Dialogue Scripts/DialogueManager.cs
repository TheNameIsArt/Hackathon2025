using Cinemachine;
using DialogueEditor;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    private Dictionary<string, string> savedConversationNames = new Dictionary<string, string>();

    public CinemachineVirtualCamera localCamera;
    public CinemachineVirtualCamera virtualCamera;
    public bool cameraSwitched = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public bool TryGetSavedConversation(string characterID, NPCConversation[] possibleConversations, out NPCConversation conversation)
    {
        if (savedConversationNames.TryGetValue(characterID, out var savedName))
        {
            conversation = System.Array.Find(possibleConversations, c => c.name == savedName);
            return conversation != null;
        }

        conversation = null;
        return false;
    }

    public void RegisterDialogueState(string characterID, NPCConversation conversation)
    {
        if (conversation != null)
        {
            savedConversationNames[characterID] = conversation.name;
        }
    }

    private void Update()
    {
        // Find the local camera (Camera_Conversation) if it hasn't been assigned
        if (localCamera == null)
        {
            GameObject parentCamera = GameObject.Find("Camera");
            if (parentCamera != null)
            {
                localCamera = parentCamera.transform.Find("Camera_Conversation")?.GetComponent<CinemachineVirtualCamera>();
            }
        }

        // Find the virtual camera (Camera_MainArcade) if it hasn't been assigned
        if (virtualCamera == null)
        {
            GameObject parentCamera = GameObject.Find("Camera");
            if (parentCamera != null)
            {
                virtualCamera = parentCamera.transform.Find("Camera_MainArcade")?.GetComponent<CinemachineVirtualCamera>();
            }
        }

        // Check if the conversation is active and switch cameras accordingly
        if (ConversationManager.Instance.IsConversationActive)
        {
            cameraSwitched = true;
            if (localCamera != null)
            {
                Scr_CameraController.SwitchCamera(localCamera);
            }
        }
        else if (!ConversationManager.Instance.IsConversationActive && cameraSwitched)
        {
            cameraSwitched = false;
            if (virtualCamera != null)
            {
                Scr_CameraController.SwitchCamera(virtualCamera);
            }
        }
    }
}