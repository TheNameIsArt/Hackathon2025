using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Inventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryCanvas;
    [SerializeField] private GameObject controlCanvas;


    public bool isInventoryOpen = false;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryCanvas.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void ToggleInventory(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!isInventoryOpen)
            {
                controlCanvas.SetActive(false);
                inventoryCanvas.SetActive(true);
                isInventoryOpen = true;
            }
            else if (isInventoryOpen)
            {
                controlCanvas.SetActive(true);
                inventoryCanvas.SetActive(false);
                isInventoryOpen = false;
            }
        } 
    }

}
