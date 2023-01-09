using UnityEngine;
using FMODUnity;
public class WinText : MonoBehaviour
{
    [SerializeField] EventReference WinSFX;
    // Start is called before the first frame update
    void OnEnable()
    {
        RuntimeManager.PlayOneShot(WinSFX);
        //play WIN SFX HERE
    }
}
