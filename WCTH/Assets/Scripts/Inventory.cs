using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    private bool isInventoryOpen = false;
    private List<string> items = new List<string>();

    void Start()
    {
        // Initialize inventory with some items (optional)
        items.Add("magnifying glass");
        items.Add("Notes");
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
        Debug.Log("Inventory Opened");
        foreach (var item in items)
        {
            Debug.Log("Item: " + item);
        }
    }

    private void CloseInventory()
    {
        Debug.Log("Inventory Closed");
    }
}
