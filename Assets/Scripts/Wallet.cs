// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wallet", fileName = "New Wallet")]
public class Wallet : ScriptableObject
{
    [SerializeField] Globals G;
    public int HomeGold;
    public int LairGold;
    public int SmallWallet = 500;
    public int MediumWallet = 750;
    public int BiggestWallet = 1000;
    public int PocketSize => G.walletUpgrade2 ? BiggestWallet : G.walletUpgrade1 ? MediumWallet : SmallWallet;

    public float EncumbermentFactor => (float)LairGold / (float)PocketSize;

    void OnEnable()
    {
        HomeGold = 0;
        LairGold = 0;
    }

    public void AddLairGold(int amount)
    {
        LairGold = Mathf.Clamp(LairGold + amount, 0, PocketSize);
    }

    public void StoreGoldAtHome()
    {
        HomeGold += LairGold;
        LairGold = 0;
    }
}
