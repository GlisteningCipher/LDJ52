using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Intuition", fileName = "Intuition")]
public class Intuition : Upgrade
{
    public override bool CanBuy()
    {
        return base.CanBuy() && globals.intuitionUpgrade == false;
    }

    public override void Buy()
    {
        base.Buy();
        globals.intuitionUpgrade = true;
    }
}