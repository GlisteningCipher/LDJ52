using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Food", fileName = "New Food")]
public class Food : Upgrade
{
    public override bool CanBuy()
    {
        return base.CanBuy() && globals.wellFed == false;
    }

    public override void Buy()
    {
        base.Buy();
        globals.wellFed = true;
    }
}