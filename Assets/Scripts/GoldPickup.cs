using System;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class GoldPickup : MonoBehaviour
{
    public int value;

    public event Action<GoldPickup> OnPickup;

    [SerializeField]
    private EventReference coinSFX;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<PlayerController>())
        {
            OnPickup?.Invoke(this);
            gameObject.SetActive(false);

            RuntimeManager.PlayOneShotAttached(coinSFX, gameObject);
        }
    }
}
