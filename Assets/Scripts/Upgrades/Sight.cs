using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Sight", fileName = "Sight")]
public class Sight : Upgrade
{
    public override bool CanBuy()
    {
        return base.CanBuy() && globals.sightUpgrade == false;
    }

    public override void Buy()
    {
        base.Buy();
        globals.sightUpgrade = true;
    }
}