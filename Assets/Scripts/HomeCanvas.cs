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
        EnterAnimation();
    }

    public Tween EnterAnimation()
    {
        return HomePanel.DOLocalMoveY(HomePanel.localPosition.y, AnimTime).From(StartingYPos);
    }

    public Tween ExitAnimation()
    {
        return HomePanel.DOLocalMoveY(StartingYPos, AnimTime);
    }

    public void EnterTheDragon()
    {
        ExitAnimation().OnComplete(()=> SceneManager.LoadScene(DragonScene.name));
    }

    public void ClosePanel()
    {
        ExitAnimation();
    }
}
