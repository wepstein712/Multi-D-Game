using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject levelManager = null;
    public GameObject soundManager = null;
    public GameObject settingsManager = null;

    // Start is called before the first frame update
    void Awake()
    {
        if (LevelManager.instance == null)
        {
            Instantiate(levelManager);
        }

        if(SoundManager.instance == null)
        {
            Instantiate(soundManager);
        }

        if(SettingsManager.instance == null)
        {
            Instantiate(settingsManager);
        }
    }
}
