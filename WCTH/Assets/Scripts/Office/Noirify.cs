using UnityEngine;

public class Noirify : MonoBehaviour
{
    // Assign the material to greyscale player character
    [SerializeField] private Material noirColour;
    [SerializeField] private GameObject objectToMaterialize;

    void Start()
    {
        // Find the gameobject tagged with "player"
        objectToMaterialize = GameObject.FindGameObjectWithTag("Player");
        // Assign the greyscale material to the gameobject found
        objectToMaterialize.GetComponent<Renderer>().material = noirColour;
    }
}