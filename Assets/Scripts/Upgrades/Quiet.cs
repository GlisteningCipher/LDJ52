using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Quiet", fileName = "Quiet")]
public class Quiet : Upgrade
{
    public override bool CanBuy()
    {
        return base.CanBuy() && globals.quietUpgrade == false;
    }

    public override void Buy()
    {
        base.Buy();
        globals.quietUpgrade = true;
    }
}