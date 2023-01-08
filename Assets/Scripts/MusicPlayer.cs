using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] EventReference music;
    EventInstance musicToPlay;
    [SerializeField] AlertBar alertBar = null;
    // Start is called before the first frame update
    void Start()
    {
        musicToPlay = RuntimeManager.CreateInstance(music);
        musicToPlay.start();
    }

    // Update is called once per frame
    void Update()
    {
        if (alertBar!=null)
        {
            musicToPlay.setParameterByName("Dragon", alertBar.alertness);
            Debug.Log(alertBar.alertness);
        }
    }

    private void OnDisable()
    {
        musicToPlay.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        musicToPlay.release();
    }
}
