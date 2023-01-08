using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Disguise", fileName = "New Disguise")]
public class Disguise : Upgrade
{
    public override bool CanBuy()
    {
        return base.CanBuy() && globals.disguiseUpgrade == false;
    }

    public override void Buy()
    {
        base.Buy();
        globals.disguiseUpgrade = true;
    }
}