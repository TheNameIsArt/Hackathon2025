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

        // Deactivate all item prefabs at the start
        for (int i = 1; i <= 8; i++) // Assuming a maximum of 8 item prefabs
        {
            GameObject itemPrefab = GameObject.Find("Item" + i);
            if (itemPrefab != null)
            {
                itemPrefab.SetActive(false);
            }
        }

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
            for (int i = 0; i < items.Count; i++)
            {
                GameObject itemPrefab = GameObject.Find("Item" + (i + 1));
                if (itemPrefab != null)
                {
                    itemPrefab.SetActive(true);
                    Debug.Log("Activated: " + itemPrefab.name);
                }
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
