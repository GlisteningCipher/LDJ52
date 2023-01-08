using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHide : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pl = collision.GetComponent<PlayerController>();

        if (pl)
            pl.isHidden(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController pl = collision.GetComponent<PlayerController>();
        if (pl)
            pl.isHidden(false);
    }
}
