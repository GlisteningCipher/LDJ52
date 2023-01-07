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
    [SerializeField] Wallet wallet;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer sprite;

    Rigidbody2D rb;
    Vector2 input;

    bool isWalking => input != Vector2.zero;

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
        anim.SetBool("isWalking", isWalking);

        if (!isWalking) return;

        var force = new Vector2(horizontalSpeed, verticalSpeed) * input;
        rb.AddForce(force);
        if (rb.velocity.x > 0) sprite.flipX = true;
        else if (rb.velocity.x < 0) sprite.flipX = false;

        //walk noise + goldCollected
        alertBar.Increase((Mathf.Abs(rb.velocity.x + rb.velocity.y)) / 100);
    }

    public void CollectGold(int gold)
    {
        Debug.Log("Picked up " + gold + " gold");
        wallet.AddLairGold(gold);
        alertBar.Increase(goldCollected / 4);
    }
}
