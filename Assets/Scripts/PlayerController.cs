// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{   
    [Header("References")]
    [SerializeField] AlertBar alertBar;
    [SerializeField] Wallet wallet;
    [SerializeField] Globals globals;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer sprite;

    [Header ("Speed Settings")]
    [SerializeField] float verticalSpeed;
    [SerializeField] float horizontalSpeed;
    [SerializeField] float baseDrag = 100f;
    [SerializeField] float wellFedMaxDrag = 300f;
    [SerializeField] float regularMaxDrag = 500f;

    Rigidbody2D rb;
    Vector2 input;

    bool isWalking => input != Vector2.zero;
    bool isFrozen = false;

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

        if (!isWalking || isFrozen) return;

        var force = new Vector2(horizontalSpeed, verticalSpeed) * input;
        rb.AddForce(force);
        if (rb.velocity.x > 0) sprite.flipX = true;
        else if (rb.velocity.x < 0) sprite.flipX = false;

        alertBar.Increase((Mathf.Abs(rb.velocity.x + rb.velocity.y)) / 100);
    }

    public void CollectGold(int gold)
    {
        Debug.Log("Collected " + gold + " gold!");
        wallet.AddLairGold(gold);
        alertBar.Increase(gold / 4);
        var upperDrag = globals.wellFed ? wellFedMaxDrag : regularMaxDrag;
        var additionalDrag = (upperDrag-baseDrag) * wallet.EncumbermentFactor;
        rb.drag = baseDrag + additionalDrag;
    }

    public void FrozenPlayer(bool f)
    {
        isFrozen = f;
    }
}
