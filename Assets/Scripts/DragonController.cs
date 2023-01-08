using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;
using FMOD.Studio;

public class DragonController : MonoBehaviour
{
    [SerializeField] Animator anim;

    [SerializeField] EventReference dragonRoar;
    private bool isAwake;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void WakeUp()
    {
        if (!isAwake)
        {
            RuntimeManager.PlayOneShotAttached(dragonRoar, gameObject);
        }
        anim.SetBool("isAlerted", true);      
        isAwake = true;
    }

    public void BackToSleep()
    {
        anim.SetBool("isAlerted", false);
        isAwake = false;
    }

}