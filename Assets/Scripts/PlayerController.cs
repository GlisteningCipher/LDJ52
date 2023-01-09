// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using DG.Tweening;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{   
    [Header("References")]
    [SerializeField] AlertBar alertBar;
    [SerializeField] Wallet wallet;
    [SerializeField] Globals globals;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] GameObject hiddenIcon;
    public bool isPlayerHidden = false;
    [SerializeField] TextMeshProUGUI goldText;

    [Header ("Speed Settings")]
    [SerializeField] float verticalSpeed;
    [SerializeField] float horizontalSpeed;
    [SerializeField] float baseDrag = 100f;
    [SerializeField] float wellFedMaxDrag = 300f;
    [SerializeField] float regularMaxDrag = 500f;
    [SerializeField] float speedUpgradeMultiplier = 1.5f;
    [SerializeField, Range(0f,1f)] float quietMultiplier = 0.5f;

    [Header("SFX")]
    [SerializeField] EventReference walkingSFX;
    [SerializeField] [ParamRef] string reverbParam;
    [SerializeField] Transform reverbAttenuation;
    int goldSFXLimit;
    EventInstance footstepsSFX;
    float reverbDistance;


    Rigidbody2D rb;
    Vector2 input;

    bool isWalking => input != Vector2.zero;
    bool isFrozen = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        hiddenIcon.SetActive(false);
        goldText.text = "000";
    }


    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        reverbDistance = (10* (Vector2.Distance(new Vector2 (transform.position.x, 0), new Vector2 (reverbAttenuation.position.x, 0))))*0.2f;
        RuntimeManager.StudioSystem.setParameterByName(reverbParam, reverbDistance);
        //Debug.Log(reverbDistance);
    }

    void FixedUpdate()
    {
        anim.SetBool("isWalking", isWalking);
            
        
        if (!isWalking || isFrozen)
        {
            footstepsSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            footstepsSFX.release();
            return;
        }

        if (!IsPlaying(footstepsSFX))
        {
            footstepsSFX = RuntimeManager.CreateInstance(walkingSFX);
            footstepsSFX.setParameterByName("Weight", goldSFXLimit);
            footstepsSFX.start();
        }

        var force = new Vector2(horizontalSpeed, verticalSpeed) * input * (globals.speedUpgrade ? speedUpgradeMultiplier : 1f);
        rb.AddForce(force);
        if (rb.velocity.x > 0) sprite.flipX = true;
        else if (rb.velocity.x < 0) sprite.flipX = false;

        var alertGenerated = (Mathf.Abs(rb.velocity.x + rb.velocity.y)) / 100;
        if (globals.quietUpgrade) alertGenerated *= quietMultiplier;
        alertBar.Increase(alertGenerated);
    }

    public void CollectGold(int gold)
    {
        //Debug.Log("Collected " + gold + " gold!");
        int g = int.Parse(goldText.text) + gold;
        goldText.text = g.ToString("D3");
        wallet.AddLairGold(gold);
        alertBar.Increase(gold / 4);
        var upperDrag = globals.wellFed ? wellFedMaxDrag : regularMaxDrag;
        var additionalDrag = (upperDrag-baseDrag) * wallet.EncumbermentFactor;
        rb.drag = baseDrag + additionalDrag;

        if(wallet.LairGold <= 100)
        {
            goldSFXLimit = wallet.LairGold;
        } else
        {
            goldSFXLimit = 100;
        }
        footstepsSFX.setParameterByName("Weight", goldSFXLimit);
        Debug.Log(goldSFXLimit);

    }

    public void FrozenPlayer(bool f)
    {
        isFrozen = f;
    }
    bool IsPlaying(EventInstance instance)
    {
        PLAYBACK_STATE state;
        instance.getPlaybackState(out state);
        return state != PLAYBACK_STATE.STOPPED;
    }

    private void OnDisable()
    {
        footstepsSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        footstepsSFX.release();
    }

    public void isHidden(bool h)
    {
        isPlayerHidden = h;
        hiddenIcon.SetActive(isPlayerHidden);
    }
}
