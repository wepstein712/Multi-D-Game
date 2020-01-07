using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    //public Slider masterVolume;
    private AudioSource source;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        source = GetComponent<AudioSource>();
        source.volume = PlayerPrefs.GetFloat("master", 0.75f);

    }

    public void UpdateVolume()
    {
        source.volume = PlayerPrefs.GetFloat("master");
    }
}
