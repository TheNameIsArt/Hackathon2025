    using UnityEngine;
    using UnityEngine.InputSystem;
public class SpaceshipMovement : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    

    void Update()
    {
       
    }

    private void OnMouseDown()
    {
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
}