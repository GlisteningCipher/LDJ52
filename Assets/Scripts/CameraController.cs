using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera PlayerCamera;
    [SerializeField] CinemachineVirtualCamera DragonCamera;
    [SerializeField] string LookButton = "Jump";
    bool alerted = false;

    public void LookPlayer()
    {
        PlayerCamera.Priority = 1;
        DragonCamera.Priority = 0;
    }

    public void LookDragon()
    {
        PlayerCamera.Priority = 0;
        DragonCamera.Priority = 1;
    }

    void Update()
    {
        if(!alerted)
        {
            if (Input.GetButtonDown(LookButton))
                LookDragon();
            if (Input.GetButtonUp(LookButton))
                LookPlayer();
        }
    }

    public void Alert(bool a)
    {
        alerted = a;
    }
}
