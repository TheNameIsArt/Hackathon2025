using Cinemachine;
using UnityEngine;

public class Scr_SwitchCamera : MonoBehaviour
{
    public CinemachineVirtualCamera cam1;
    public CinemachineVirtualCamera cam2;
    public CinemachineVirtualCamera cam3;
    public CinemachineVirtualCamera cam4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Scr_CameraController.SwitchCamera(cam1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Scr_CameraController.SwitchCamera(cam2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Scr_CameraController.SwitchCamera(cam3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Scr_CameraController.SwitchCamera(cam4);
        }
    }
}
