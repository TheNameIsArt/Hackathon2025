using UnityEngine;
using UnityEngine.InputSystem;

public class Scr_InventoryItems : MonoBehaviour, IPressable
{
   public bool itemFound = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (itemFound)
        {
            gameObject.SetActive(true);
        }
    }
    public void OnPress(InputAction.CallbackContext context)
    {
        Debug.Log("Item Pressed: " + gameObject.name);
    }
}
