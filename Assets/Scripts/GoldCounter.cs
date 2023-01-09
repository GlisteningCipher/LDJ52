using UnityEngine;
using TMPro;

public class GoldCounter : MonoBehaviour
{
    [SerializeField] Wallet wallet;
    [SerializeField] TextMeshProUGUI goldCounter;

    void Update()
    {
        goldCounter.text = wallet.HomeGold.ToString("D5");
    }
}
