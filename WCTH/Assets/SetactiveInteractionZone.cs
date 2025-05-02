using UnityEngine;

public class SetActiveInteractionZone : MonoBehaviour
{
    public GameObject targetObject; // The GameObject to be activated



    // Method to set the target GameObject active
    public void ActivateObject()
    {
            targetObject.SetActive(true);
    }
}
