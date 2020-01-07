using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Writes to PlayerPrefs to store user settings
public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance = null;

    private float masterVolume;

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

    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("master"))
        {
            masterVolume = PlayerPrefs.GetFloat("master");
        } else
        {
            masterVolume = 1.0f;
        }
        PlayerPrefs.Save();
    }

    public void SetSliderValue(Slider slider)
    {
        PlayerPrefs.SetFloat("master", slider.value);
    }

    public void SavePlayerPrefs()
    {
        PlayerPrefs.Save();
    }
    
}
