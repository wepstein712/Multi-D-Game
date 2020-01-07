using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;
public class EnemyBehavior : MonoBehaviour
{
    public float fov_angle = 110f;
    public bool player_in_sight;
    public float sightDistance = 10;
    public Vector3 personalLastSighting;
    private bool clockwise = true;
    private bool straight_ahead = false;
    private float rotation_speed;
    private float time;
    private float nextCheck;
    public GameObject player;
    public bool is2D = false;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        rotation_speed = 15f * Time.deltaTime;
        time = 0f;
        nextCheck = .2f;
        if (sightDistance < 10)
        {
            sightDistance = 10;
        }
        print("SIGHT DISTANCE: " + sightDistance);
        agent.SetDestination(player.transform.position);

      //  print(SceneView.CameraMode.drawMode);

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        /*
        if (!player_in_sight)
        {
            transform.Rotate(0f, rotation_speed, 0f);
        } else
        {
            if (!straight_ahead)
            {
                if (clockwise)
                {
                    transform.Rotate(0f, rotation_speed, 0f);
                }
                else
                {
                    transform.Rotate(0f, rotation_speed, 0f);
                }
            }
        }
        */
        transform.Rotate(0f, rotation_speed, 0f);

  
    }

    bool lineOfSight(GameObject g, float maxDist)
    {
        print(g.tag);
        if (Mathf.Abs(Vector3.Distance(transform.position, g.transform.position)) < maxDist)
        {
           // print("within dist");
            RaycastHit hit;
            
            if (Physics.Raycast(transform.position, g.transform.position - transform.position, out hit, maxDist))
            {
               // print("did a hit");
                Debug.DrawLine(transform.position, hit.point, Color.blue);
                print(hit.collider.tag + " " + hit.collider.name);
                if ((hit.collider.gameObject.CompareTag(g.tag)) || (hit.collider.gameObject.CompareTag("Player")) && Mathf.Abs(Vector3.Angle(transform.forward, (g.transform.position - transform.position))) < fov_angle)
                {
                    //print("within angle and its the player");
                    return true;
                } else if (hit.collider.gameObject.CompareTag(g.tag))
                {
                    //print("not within angle: " + Mathf.Abs(Vector3.Angle(transform.forward, (g.transform.position - transform.position))));
                } else
                {
                   // print("not right tag:" + hit.collider.name);
                }
            }
            
        }
        return false;
    }

    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.forward * 10, Color.magenta);
        if (lineOfSight(player, sightDistance))
        {
            agent.SetDestination(player.transform.position);
            if (!agent.hasPath)
            {
                print("Cannot get there!");
            }
            //moveToPlayer();
            Vector3 facing_dir = player.transform.position - transform.position;
            Debug.DrawRay(transform.position, facing_dir, Color.red);
            float a = Vector3.Angle(facing_dir, transform.forward);
           // print("Angle: " + a);
            if (Mathf.Abs(a) <= 20)
            {
                rotation_speed = 0f;

            }
            else if (a > 20)
            {
                clockwise = true;
                rotation_speed = a * Time.deltaTime;
            }
            else if (a < - 20)
            {
                clockwise = false;
                rotation_speed = a * Time.deltaTime;
            }
            player_in_sight = true;
        } else
        {
           // print("Agent: " + agent.path);
        }
      
    }
    /*
    private void moveToPlayer()
    {
        agent.destination = player.transform.position;
        agent.Resume();
        print("moving");
    }
    */
    private void moveTowardsPlayer(Vector3 dir)
    {
        //agent.destination = pos;

        //agent.Resume();
        transform.position += dir * Time.deltaTime;

    }
}
