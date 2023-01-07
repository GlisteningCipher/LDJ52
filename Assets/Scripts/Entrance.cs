using UnityEngine;
using UnityEngine.SceneManagement;

public class Entrance : MonoBehaviour
{
    [SerializeField] Object HomeScene;

    void OnTriggerEnter2D()
    {
        SceneManager.LoadScene(HomeScene.name);
    }
}
