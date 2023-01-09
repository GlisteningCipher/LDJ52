using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Quests : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Globals G;
    [SerializeField] Wallet PlayerWallet;
    [SerializeField] Button PayButton;
    [SerializeField] TextMeshProUGUI Dialogue;
    [SerializeField] UnityEvent OnAllQuestsFinished;

    [Header("Quests")]
    public List<Quest> QuestList;


    void Awake()
    {
        PayButton.onClick.AddListener(SubmitQuest);
        Dialogue.text = QuestList[G.questIndex].Dialogue;
    }

    void Update()
    {
        if (G.questIndex < QuestList.Count)
            PayButton.interactable = PlayerWallet.HomeGold >= QuestList[G.questIndex].Price;
        else
            PayButton.interactable = true;
    }

    void SubmitQuest()
    {
        PlayerWallet.HomeGold -= QuestList[G.questIndex].Price;
        PayButton.interactable = false;
        Dialogue.text = QuestList[G.questIndex].Response;
        G.questIndex += 1;

        //if the last quest was just submitted
        if (G.questIndex == QuestList.Count)
        {
            PayButton.interactable = true;
            PayButton.GetComponentInChildren<TextMeshProUGUI>().text = "Finish";
            PayButton.onClick.RemoveAllListeners();
            PayButton.onClick.AddListener(()=>OnAllQuestsFinished.Invoke());
        }
    }
}

[Serializable]
public struct Quest
{
    public int Price;
    [TextArea(3,10)] public string Dialogue;
    [TextArea(3,10)] public string Response;
}
