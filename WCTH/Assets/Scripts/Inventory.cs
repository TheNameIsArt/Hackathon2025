using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    private bool isInventoryOpen = false;
    [SerializeField]GameObject inventoryCanvas;
    private List<Item> items = new List<Item>();
    private InventoryUI inventoryUI;

    void Start()
    {
        inventoryUI = Object.FindFirstObjectByType<InventoryUI>();

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
        if (inventoryCanvas != null)
        {
            inventoryCanvas.SetActive(true);
        }

        Debug.Log("Inventory Opened");

        if (items.Count == 0)
        {
            Debug.Log("No items in the inventory.");
        }
        else
        {
            foreach (var item in items)
            {
                Debug.Log("Item: " + item);
            }
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
