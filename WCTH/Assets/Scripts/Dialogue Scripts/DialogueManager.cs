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
        if (ConversationManager.Instance.IsConversationActive)
        {
            cameraSwitched = true;
            localCamera = GameObject.Find("Camera_Conversation").GetComponent<CinemachineVirtualCamera>();
            Scr_CameraController.SwitchCamera(localCamera);
        }
        else if (!ConversationManager.Instance.IsConversationActive && cameraSwitched)
        {
            cameraSwitched = false;
            virtualCamera = GameObject.Find("Camera_MainArcade").GetComponent<CinemachineVirtualCamera>();
            Scr_CameraController.SwitchCamera(virtualCamera);
        }
    }
}