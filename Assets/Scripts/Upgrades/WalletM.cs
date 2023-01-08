using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/WalletM", fileName = "WalletM")]
public class WalletM : Upgrade
{
    public override bool CanBuy()
    {
        return base.CanBuy() && globals.walletUpgrade1 == false;
    }

    public override void Buy()
    {
        base.Buy();
        globals.walletUpgrade1 = true;
    }
}