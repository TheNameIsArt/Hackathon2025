using UnityEngine;
using UnityEngine.InputSystem;

public interface IPressable 
{
    void OnPress(InputAction.CallbackContext context);
}

