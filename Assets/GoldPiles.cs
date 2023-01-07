using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPiles : MonoBehaviour
{
    [SerializeField] List<GoldPickup> _goldPiles;
    [SerializeField] List<GoldPickup> _goldPilesRemaining;
    [SerializeField] PlayerController player;

    void OnEnable()
    {
        AutoFillCollectibles();
        _goldPilesRemaining = new List<GoldPickup>(_goldPiles);

        foreach (var gold in _goldPilesRemaining)
            gold.OnPickup += CollectGold;
    }

    void CollectGold(GoldPickup g)
    {
        player.CollectGold(g.value);
        _goldPilesRemaining.Remove(g);
    }

    [ContextMenu("AutoFill GoldPickups")]
    void AutoFillCollectibles()
    {
        _goldPiles = GetComponentsInChildren<GoldPickup>().ToList();
    }
}