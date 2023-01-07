using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertBar : MonoBehaviour
{
    [Range(0f, 100f)]
    [SerializeField] float alertness;
    Slider alertBar;

    [SerializeField] GameObject dragon;
    [SerializeField] GameObject player;

    [Header("Debug Vars")]
    [SerializeField] bool debug;

    void Awake()
    {
        alertBar = GetComponent<Slider>();
        alertBar.value = 0f;
        toggleVisibility(debug ? true : false);
    }

    void Update()
    {
        if(alertness >= 100)
        {
            Debug.Log("DRAGON WAKES UP");
        }

        if(!debug) toggleVisibility(distanceToDragon() <= 15 ? true : false);
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
        alertness += (a);
        alertBar.value = alertness;
    }
}
