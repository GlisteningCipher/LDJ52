using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/WalletL", fileName = "WalletL")]
public class WalletL : Upgrade
{
    public override bool CanBuy()
    {
        return base.CanBuy() && globals.walletUpgrade1 && !globals.walletUpgrade2;
    }

    public override void Buy()
    {
        base.Buy();
        globals.walletUpgrade2 = true;
    }
}