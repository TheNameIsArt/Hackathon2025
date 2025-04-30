using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    private bool isInventoryOpen = false;
    private List<string> items = new List<string>();
    [SerializeField]GameObject inventoryCanvas;

    void Start()
    {
        // Initialize inventory with some items (optional)
        items.Add("magnifying glass");
        items.Add("Notes");

        //inventoryCanvas = GameObject.Find("InventoryCanvas");
        CloseInventory();
    }

    public void OnInventoryToggle(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ToggleInventory();
        }
    }

    private void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        if (isInventoryOpen)
        {
            OpenInventory();
        }
        else
        {
            CloseInventory();
        }
    }

    private void OpenInventory()
    {
        isInventoryOpen = true;

        // Activate the Inventory canvas and all its children
        //GameObject inventoryCanvas = GameObject.Find("InventoryCanvas");
        if (inventoryCanvas != null)
        {
            inventoryCanvas.SetActive(true);
        }

        Debug.Log("Inventory Opened");

        foreach (var item in items)
        {
            Debug.Log("Item: " + item);
        }
    }

    private void CloseInventory()
    {
        isInventoryOpen = false;

        // Deactivate the Inventory canvas and all its children
        
        if (inventoryCanvas != null)
        {
            inventoryCanvas.SetActive(false);
        }

        Debug.Log("Inventory Closed");
    }
}
