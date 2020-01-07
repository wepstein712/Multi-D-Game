using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public GameObject player;
    private Vector3 offset;


   private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 relativePosn = player.transform.InverseTransformPoint(offset);
        print(relativePosn);
        transform.position = player.transform.TransformPoint(relativePosn);
        Debug.DrawRay(player.transform.position, player.transform.forward, Color.red);
        //transform.Rotate(target.up, Vector3.Angle(transform.forward, target.forward), Space.World);
        transform.LookAt(target);
    }


}
