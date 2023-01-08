using UnityEngine;
using FMODUnity;

public class Shop : MonoBehaviour
{
    [SerializeField] Globals G;
    [SerializeField] Upgrade[] Upgrades;
    [SerializeField] CanvasGroup[] UpgradeUI;
    
    [SerializeField] EventReference buySFX;

    void Awake()
    {
        G.wellFed = false;
    }

    void Start()
    {
        Redraw();
    }

    [ContextMenu("Redraw")]
    public void Redraw()
    {
        for (int i = 0; i < Upgrades.Length; i++)
        {
            bool canBuy = Upgrades[i].CanBuy();
            UpgradeUI[i].alpha = canBuy ? 1f : 0.33f;
            UpgradeUI[i].interactable = canBuy;
        }
    }

    public void PurchaseUpgrade(int index)
    {
        Upgrades[index].Buy();
        Redraw();

        RuntimeManager.PlayOneShot(buySFX);
    }
}
