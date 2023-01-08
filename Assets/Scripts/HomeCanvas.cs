using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class HomeCanvas : MonoBehaviour
{
    [SerializeField] Object DragonScene;
    [SerializeField] RectTransform HomePanel;
    [SerializeField] float StartingYPos;
    [SerializeField] float AnimTime = 0.5f;

    void Start()
    {
        HomePanel.DOLocalMoveY(HomePanel.localPosition.y, AnimTime).From(StartingYPos);
    }

    public void EnterTheDragon()
    {
        SceneManager.LoadScene(DragonScene.name);
    }
}
