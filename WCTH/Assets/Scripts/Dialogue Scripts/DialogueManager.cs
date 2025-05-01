using Cinemachine;
using DialogueEditor;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    private Dictionary<string, string> savedConversationNames = new Dictionary<string, string>();

    public CinemachineVirtualCamera localCamera;
    public bool cameraSwitched = false;

    private CinemachineVirtualCamera savedLiveCamera; // To store the live camera from the CinemachineBrain

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

        // Get the CinemachineBrain component
        CinemachineBrain brain = Camera.main?.GetComponent<CinemachineBrain>();
        if (brain == null) return;

        // Check if the conversation is active and switch cameras accordingly
        if (ConversationManager.Instance.IsConversationActive)
        {
            if (!cameraSwitched)
            {
                cameraSwitched = true;

                // Save the currently active (live) camera from the CinemachineBrain
                if (brain.ActiveVirtualCamera is CinemachineVirtualCamera virtualCamera)
                {
                    savedLiveCamera = virtualCamera;
                }
                else
                {
                    Debug.LogWarning("Active virtual camera is not a CinemachineVirtualCamera.");
                }

                if (localCamera != null)
                {
                    Scr_CameraController.SwitchCamera(localCamera);
                }
                if (localCamera == null)
                {
                    GameObject parentCamera = GameObject.Find("Camera");
                    if (parentCamera != null)
                    {
                        localCamera = parentCamera.transform.Find("Camera_Conversation")?.GetComponent<CinemachineVirtualCamera>();
                        if (localCamera != null)
                        {
                            Debug.Log($"localCamera assigned: {localCamera.name}");
                        }
                        else
                        {
                            Debug.LogWarning("Camera_Conversation not found or does not have a CinemachineVirtualCamera component.");
                        }
                    }
                    else
                    {
                        Debug.LogWarning("Parent camera (Camera) not found.");
                    }
                }
            }
        }
        else if (!ConversationManager.Instance.IsConversationActive && cameraSwitched)
        {
            cameraSwitched = false;

            // Restore the saved live camera
            if (savedLiveCamera != null)
            {
                Scr_CameraController.SwitchCamera(savedLiveCamera);
            }
        }
    }
}
