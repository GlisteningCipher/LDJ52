using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldNest : MonoBehaviour
{
    bool atTheNest = false;
    [SerializeField] PlayerController pl;

    void Update()
    {
        if (atTheNest && Input.GetButtonDown("Fire1"))
        {
            pl.CollectGold(Random.Range(0f, 1f) > .5f ? 25 : 50);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Show 'Press E' Dialog");
        atTheNest = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Dismiss 'Press E' Dialog");
        atTheNest = false;
    }
}
