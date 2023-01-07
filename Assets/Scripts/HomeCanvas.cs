using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeCanvas : MonoBehaviour
{
    [SerializeField] Object DragonScene;

    public void EnterTheDragon()
    {
        SceneManager.LoadScene(DragonScene.name);
    }
}
