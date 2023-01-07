using UnityEngine;
using UnityEngine.SceneManagement;

public class Entrance : MonoBehaviour
{
    [SerializeField] Object HomeScene;
    [SerializeField] Wallet Wallet;

    void OnTriggerEnter2D()
    {
        Wallet.StoreGoldAtHome();
        SceneManager.LoadScene(HomeScene.name);
    }
}
