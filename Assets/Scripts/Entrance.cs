using UnityEngine;
using UnityEngine.SceneManagement;

public class Entrance : MonoBehaviour
{
    [SerializeField] Wallet Wallet;
    [SerializeField] Globals globals;

    void OnTriggerEnter2D()
    {
        globals.suspicion += Wallet.LairGold / 4;
        Wallet.StoreGoldAtHome();
        SceneManager.LoadScene("HomeScene");
    }
}