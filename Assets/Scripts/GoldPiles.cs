using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPiles : MonoBehaviour
{
    [SerializeField] List<GoldPickup> _goldPiles;
    [SerializeField] List<GoldPickup> _goldPilesRemaining;
    [SerializeField] PlayerController player;

    [SerializeField] GameObject[] goldPrefabs;
    [SerializeField] Transform[] goldSpawns;

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
        List<Transform> spawns = goldSpawns.ToList();
        for(int i = 0; i < 7; i++)
        {
            GameObject g = Instantiate(goldPrefabs[Random.Range(0, goldPrefabs.Length)], gameObject.transform);
            Transform pos = spawns[Random.Range(0, spawns.Count)];
            g.transform.position = pos.position;
            g.GetComponent<SpriteRenderer>().sortingOrder = pos.GetComponent<SpriteRenderer>().sortingOrder;
            spawns.Remove(pos);
        }
        
        foreach (Transform g in transform)
        {
            if (Random.Range(0f, 1f) > 0.71f) Destroy(g.gameObject);
        }

        _goldPiles = GetComponentsInChildren<GoldPickup>().ToList();
    }
}