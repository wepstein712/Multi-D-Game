using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerMinion3D : MonoBehaviour
{
    public LevelManager manager;
    [Tooltip("The int ID of the scene that this object loads.")]
    public int target;
    public Text message;
    public string messageText;
    public Transform spawnPoint;

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
                manager.LoadByIndex(target);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            active = true;
            message.text = "Press F to travel";
            message.enabled = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            active = false;
        }
    }
}
