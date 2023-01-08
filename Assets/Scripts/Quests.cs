using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quests : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Globals G;
    [SerializeField] Wallet PlayerWallet;
    [SerializeField] Button PayButton;
    [SerializeField] TextMeshProUGUI Dialogue;

    [Header("Quests")]
    public List<Quest> QuestList;


    void Awake()
    {
        if (G.questIndex >= QuestList.Count)
        {
            PayButton.interactable = false;
            Dialogue.text = "No more quests!";
        }

        PayButton.interactable = PlayerWallet.HomeGold >= QuestList[G.questIndex].Price;
        PayButton.onClick.AddListener(SubmitQuest);
        Dialogue.text = QuestList[G.questIndex].Dialogue;
    }

    void SubmitQuest()
    {
        PayButton.interactable = false;
        Dialogue.text = QuestList[G.questIndex++].Response;
    }
}

[Serializable]
public struct Quest
{
    public int Price;
    [TextArea] public string Dialogue;
    [TextArea] public string Response;
}
