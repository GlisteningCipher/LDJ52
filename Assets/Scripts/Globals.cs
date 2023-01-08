using UnityEngine;

[CreateAssetMenu(menuName = "Globals", fileName = "Create")]
public class Globals : ScriptableObject
{
    [Header("Dragon Globals")]
    public int suspicion;// { get; set; }

    [Header("Player Globals")]
    public bool wellFed = false; //affects encumberment
    public bool disguiseUpgrade = false; //prevents getting caught once
    public bool speedUpgrade = false; //increases base speed
    public bool quietUpgrade = false; //alertness reduced
    public bool sightUpgrade = false; //look at dragon faster
    public bool intuitionUpgrade = false; //alert bar becomes visible
    public bool walletUpgrade1 = false; //medium sized wallet
    public bool walletUpgrade2 = false; //full sized wallet

    public int questIndex = 0;

    void OnEnable()
    {
        wellFed = disguiseUpgrade = speedUpgrade = quietUpgrade = sightUpgrade = intuitionUpgrade = walletUpgrade1 = walletUpgrade2 = false;
        questIndex = 0;
    }
}
