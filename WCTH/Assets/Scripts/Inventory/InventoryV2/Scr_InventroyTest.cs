using UnityEngine;
using UnityEngine.InputSystem;

public class Scr_InventroyTest : MonoBehaviour
{
    [SerializeField] private GameObject photo;
    [SerializeField] private GameObject wrench;
    [SerializeField] private GameObject tp;
    [SerializeField] private GameObject videoTape;
    [SerializeField] private GameObject concertTicket;
    [SerializeField] private GameObject note;
    [SerializeField] private GameObject balloon;

    [SerializeField] private GameObject inventoryManager;
    

    [SerializeField] private GameObject slot1;
    [SerializeField] private GameObject slot2;
    [SerializeField] private GameObject slot3;
    [SerializeField] private GameObject slot4;
    [SerializeField] private GameObject slot5;
    [SerializeField] private GameObject slot6;

    private Transform itemPosition;
    private int itemsFound = 0;
    private bool twoTickets = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (itemsFound == 0)
        {
            itemPosition = slot1.transform;
        }
        else if (itemsFound == 1) 
        {
            itemPosition = slot2.transform;
        }
        else if (itemsFound == 2)
        {
            itemPosition = slot3.transform;
        }
        else if (itemsFound == 3)
        {
            itemPosition = slot4.transform;
        }
        else if (itemsFound == 4)
        {
            itemPosition = slot5.transform;
        }
        else if (itemsFound == 5)
        {
            itemPosition = slot6.transform;
        }

        if (twoTickets) 
        {
            
        }

    }
    
    public void Inventory1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Inventory 1 Pressed");
            photo.SetActive(true);
            photo.transform.position = itemPosition.position;
            itemsFound++;

        }
    }
    public void Inventory2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Inventory 2 Pressed");
            wrench.SetActive(true);
            wrench.transform.position = itemPosition.position;
            itemsFound++;
        }
    }
    public void Inventory3(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Inventory 3 Pressed");
            tp.SetActive(true);
            tp.transform.position = itemPosition.position;
            itemsFound++;
        }
    }
    public void Inventory4(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Inventory 4 Pressed");
            videoTape.SetActive(true);
            videoTape.transform.position = itemPosition.position;
            itemsFound++;
        }
    }
    public void Inventory5(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Inventory 5 Pressed");
            concertTicket.SetActive(true);
            concertTicket.transform.position = itemPosition.position;
            itemsFound++;
        }
    }
    public void Inventory6(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Inventory 6 Pressed");
            note.SetActive(true);
            note.transform.position = itemPosition.position;
            itemsFound++;
        }
    }
    public void Inventory7(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Inventory 7 Pressed");
            balloon.SetActive(true);
            balloon.transform.position = itemPosition.position;
            itemsFound++;
        }
    }
    public void Inventory8(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            twoTickets = true;
        }
    }
    /*public void ItemTransform()
    {
        switch (itemsFound)
        {

            case 1:
                itemPosition = slot2.transform;
                break;
            case 2:
                itemPosition = slot3.transform;
                break;
            case 3:
                itemPosition = slot4.transform;
                break;
            case 4:
                itemPosition = slot5.transform;
                break;
            case 5:
                itemPosition = slot6.transform;
                break;
            default:
                break;
        }
    }*/

}
    
