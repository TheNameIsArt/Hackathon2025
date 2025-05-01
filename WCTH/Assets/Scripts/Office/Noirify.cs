using UnityEngine;

public class Noirify : MonoBehaviour
{
    // Assign the material to greyscale player character
    [SerializeField] private Material noirColour;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject[] noirEverything;
    [SerializeField] private GameObject noirSelector;


    void Awake()
    {
        MysteryMachine();
        Player.transform.position = new Vector3(-3.8f, -1.7f, 0);

    }

    private void MysteryMachine ()
    {
        // Find the gameobject tagged with "player"
        Player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("Added Andy as Player Object");

        // Assign the greyscale material to the gameobject found
        Player.GetComponent<Renderer>().material = noirColour;
        Debug.Log("Added Noir material");

        /*foreach (GameObject go in noirEverything)
        {
            noirSelector = GameObject.FindGameObjectWithTag("Untagged");
            noirSelector.GetComponent<Renderer>().material = noirColour;
        }*/

    }

}