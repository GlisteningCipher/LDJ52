using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPiles : MonoBehaviour
{
    [SerializeField] List<GoldPickup> _goldPiles;
    [SerializeField] List<GoldPickup> _goldPilesRemaining;
    [SerializeField] PlayerController player;
    int[] goldValues = { 10, 25, 50 };

    void OnEnable()
    {
        AutoFillCollectibles();
        _goldPilesRemaining = new List<GoldPickup>(_goldPiles);

        foreach (var gold in _goldPilesRemaining)
        {
            gold.OnPickup += CollectGold;
        }
    }

    void CollectGold(GoldPickup g)
    {
        player.CollectGold(g.value);
        _goldPilesRemaining.Remove(g);
    }

    [ContextMenu("AutoFill GoldPickups")]
    void AutoFillCollectibles()
    {
        foreach (Transform g in transform)
        {
            if (Random.Range(0f, 1f) > 0.71f) Destroy(g.gameObject);
            else
                g.GetComponent<GoldPickup>().value = goldValues[Random.Range(0,goldValues.Length)];
        }

        _goldPiles = GetComponentsInChildren<GoldPickup>().ToList();
    }
}