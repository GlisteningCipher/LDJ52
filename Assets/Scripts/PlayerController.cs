// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float verticalSpeed;
    [SerializeField] float horizontalSpeed;

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
    }
}
