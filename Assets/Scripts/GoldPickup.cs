using System;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    public int value;

    public event Action<GoldPickup> OnPickup;

    void OnTriggerEnter2D(Collider2D col)
    {
        var pl = col.GetComponent<PlayerController>();
        if (col)
        {
            OnPickup?.Invoke(this);
            gameObject.SetActive(false);
        }
    }
}
