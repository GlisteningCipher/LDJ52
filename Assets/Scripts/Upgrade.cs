using UnityEngine;

public abstract class Upgrade : ScriptableObject
{
    [SerializeField] protected Globals globals;
    [SerializeField] protected Wallet wallet;

    public int Price;

    /// <summary>
    /// Whether the item can be bought
    /// </summary>
    public virtual bool CanBuy()
    {
        return wallet.HomeGold >= Price;
    }

    /// <summary>
    /// What the item does
    /// </summary>
    public virtual void Buy()
    {
        wallet.HomeGold -= Price;
    }
}
