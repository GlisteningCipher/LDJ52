using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Globals Globals;
    [SerializeField] CinemachineVirtualCamera PlayerCamera;
    [SerializeField] CinemachineVirtualCamera DragonCamera;
    [SerializeField] CinemachineBrain Brain;
    [SerializeField] string LookButton = "Jump";
    [SerializeField] float NormalBlendTime = 1.5f;
    [SerializeField] float FasterBlendTime = 0.75f;
    bool alerted = false;

    public void LookPlayer()
    {
        Brain.m_DefaultBlend.m_Time = Globals.sightUpgrade ? FasterBlendTime : NormalBlendTime;
        PlayerCamera.Priority = 1;
        DragonCamera.Priority = 0;
    }

    public void LookDragon()
    {
        Brain.m_DefaultBlend.m_Time = Globals.sightUpgrade ? FasterBlendTime : NormalBlendTime;
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
