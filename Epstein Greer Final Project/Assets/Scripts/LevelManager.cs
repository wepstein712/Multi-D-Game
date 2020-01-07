using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;

    private bool tutorial = false;

    //Tracks the current active scene
    private int currentLevel;

    //Enforces singleton pattern
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }
    
    //Loads a scene with its index in build order as input
    public void LoadByIndex (int index)
    {
        SceneManager.LoadScene(index);
        currentLevel = index;
        if (index == 2 && !tutorial)
        {
            Canvas canvas = GetComponent<Canvas>();

            GameObject panel = canvas.transform.Find("Panel").gameObject;
            panel.SetActive(false);

        }
    }

    //Loads a scene from save file
    public void LoadFromFile()
    {

    }

    //Quits the game or exits to editor
    public void QuitOnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

    public void EndTutorial()
    {
        tutorial = true;
    }
}
