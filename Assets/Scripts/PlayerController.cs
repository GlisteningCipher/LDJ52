// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float verticalSpeed;
    [SerializeField] float horizontalSpeed;
    [SerializeField] AlertBar alertBar;
    [SerializeField] int goldCollected;

    Rigidbody2D rb;
    Vector2 input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        if (input == Vector2.zero) return;

        var force = new Vector2(horizontalSpeed, verticalSpeed) * input;
        rb.AddForce(force);

        //walk noise + goldCollected
        alertBar.Increase((Mathf.Abs(rb.velocity.x + rb.velocity.y)) / 100);
    }

    public void CollectGold(int gold)
    {
        Debug.Log("Picked up " + gold + " gold");
        goldCollected += gold;
        alertBar.Increase(goldCollected / 4);
    }
}
