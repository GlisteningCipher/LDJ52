using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertBar : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] float alertness;
    Slider alertBar;

    [SerializeField] GameObject dragon;
    [SerializeField] GameObject player;

    void Awake()
    {
        alertBar = GetComponent<Slider>();
        alertBar.value = 0f;
        toggleVisibility(false);
    }

    void Update()
    {
        alertBar.value = alertness;

        toggleVisibility(distanceToDragon() <= 30 ? true : false);
    }

    float distanceToDragon()
    {
        return (player.transform.position - dragon.transform.position).magnitude;
    }

    void toggleVisibility(bool v)
    {
        foreach (Transform ch in transform)
            ch.gameObject.SetActive(v);
    }

    public void Increase(float a)
    {
        //Debug.Log(a);
        alertness += (a);
    }
}
