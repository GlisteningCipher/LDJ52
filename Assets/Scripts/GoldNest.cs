using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldNest : MonoBehaviour
{
    bool atTheNest = false;
    [SerializeField] PlayerController pl;
    [SerializeField] GameObject canvas;

    void Update()
    {
        if (atTheNest && Input.GetButtonDown("Fire1"))
        {
            pl.CollectGold(Random.Range(0f, 1f) > .5f ? 25 : 50);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        canvas.SetActive(true); //this defaults to true so the player sees it when they approach every single time
        atTheNest = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        canvas.SetActive(false);
        atTheNest = false;
    }
}
