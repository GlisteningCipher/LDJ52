using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TownBackground : MonoBehaviour
{
    [SerializeField] Sprite HappyBackgroundImage;
    [SerializeField] Image Background;

    public void LoadHappyBackground()
    {
        Background.sprite = HappyBackgroundImage;
    }
}
