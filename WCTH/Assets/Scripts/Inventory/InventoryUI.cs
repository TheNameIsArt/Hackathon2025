using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform contentPanel;

    public void PopulateInventory(List<Item> items)
    {
        foreach (Transform child in contentPanel)
            Destroy(child.gameObject); // Clear old items

        foreach (Item item in items)
        {
            GameObject newItem = Instantiate(itemPrefab, contentPanel);
            newItem.GetComponentInChildren<Text>().text = item.itemName;
            // Additional UI setup can be added here
        }
    }
}