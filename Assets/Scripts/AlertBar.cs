using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AlertBar : MonoBehaviour
{
    [Range(0f, 100f)]
    [SerializeField] public float alertness;
    Slider alertBar;
    [SerializeField] Slider suspiciousBar;

    [SerializeField] GameObject dragon;
    [SerializeField] DragonController dragonController;
    [SerializeField] GameObject player;
    [SerializeField] Globals globals;
    Coroutine coroutine;

    [SerializeField] Animator gameOverAnim;

    void Awake()
    {
        alertBar = GetComponent<Slider>();
        //alertBar.value = 0f;
        alertness = globals.suspicion / 4;
        alertBar.value = globals.suspicion / 4;
        suspiciousBar.value = globals.suspicion / 4;
    }

    void Update()
    {
        if(alertness >= 100)
            Alert();
    }

    float distanceToDragon()
    {
        return (player.transform.position - dragon.transform.position).magnitude;
    }

    public void Increase(float a)
    {
        alertness += (a);
        alertBar.value = alertness;
    }

    void Decrease(float a)
    {
        alertness -= (a);
        alertBar.value = alertness;
    }

    void Alert()
    {
        if (coroutine == null)
            coroutine = StartCoroutine(DragonAlert());
    }

    IEnumerator DragonAlert()
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        CameraController cc = Camera.main.GetComponent<CameraController>();
        cc.Alert(true);

        playerController.FrozenPlayer(true);
        cc.LookDragon();
        dragonController.WakeUp();
        yield return new WaitForSeconds(4);
        cc.LookPlayer();
        yield return new WaitForSeconds(2);
        if (playerController.isPlayerHidden || globals.disguiseUpgrade)
        {
            if (!playerController.isPlayerHidden) globals.disguiseUpgrade = false; //consume mustache if caught
            cc.LookDragon();
            Decrease(25);
            dragonController.BackToSleep();
            yield return new WaitForSeconds(2);
            playerController.FrozenPlayer(false);
            cc.LookPlayer();
            cc.Alert(false);
            yield return null;
        }
        else
        {
            //Debug.Log("GAME OVER");
            gameOverAnim.SetBool("isGameOver", true);
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("GameOverScene");
        }
        coroutine = null;
        yield return null;
    }
}
