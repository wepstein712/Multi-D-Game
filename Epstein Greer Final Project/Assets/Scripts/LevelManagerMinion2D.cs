using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerMinion2D : MonoBehaviour
{
    public LevelManager manager;
    [Tooltip("The int ID of the scene that this object loads.")]
    public int target;
    public Text message;

    private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<LevelManager>();
        message.text = "";
        message.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Loading");
                manager.LoadByIndex(target);
            }
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entered");
            active = true;
            message.text = "Press F to travel";
            message.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited");
        if(collision.gameObject.CompareTag("Player"))
        {
            active = false;
            message.enabled = false;
        }
    }
}
