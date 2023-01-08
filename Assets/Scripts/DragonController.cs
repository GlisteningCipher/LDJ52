using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonController : MonoBehaviour
{
    [SerializeField] Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void WakeUp()
    {
        anim.SetBool("isAlerted", true);
    }

    public void BackToSleep()
    {
        anim.SetBool("isAlerted", false);
    }
}