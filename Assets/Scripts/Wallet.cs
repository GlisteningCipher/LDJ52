// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wallet", fileName = "New Wallet")]
public class Wallet : ScriptableObject
{
    public int HomeGold;
    public int LairGold;
    public int PocketSize = 500;

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
