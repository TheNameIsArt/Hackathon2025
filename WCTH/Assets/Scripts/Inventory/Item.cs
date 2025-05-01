using UnityEngine;

public interface IClickable
{
    string Description { get; }
    void OnClick();
}

public class Item : IClickable
{
    public string itemName { get; private set; }
    public string Description { get; private set; }

    public Item(string name, string description)
    {
        itemName = name;
        Description = description;
    }

    public void OnClick()
    {
        // Handle what happens when the item is clicked
        Debug.Log($"Item clicked: {itemName}. Description: {Description}");

        DisplayItemDescription();
    }
}