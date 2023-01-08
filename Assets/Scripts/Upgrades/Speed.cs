using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Speed", fileName = "New Speed")]
public class Speed : Upgrade
{
    public override bool CanBuy()
    {
        return base.CanBuy() && globals.speedUpgrade == false;
    }

    public override void Buy()
    {
        base.Buy();
        globals.speedUpgrade = true;
    }
}