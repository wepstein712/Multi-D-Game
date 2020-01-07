using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Tooltip("The speed at which the player moves on the ground.")]
    public float speed;
    [Tooltip("The force applied at the jump")]
    public float jumpForce;
    [Tooltip("The maximum speed that the player can move at.")]
    public float maxSpeed;
    [Tooltip("The speed at which the player will rotate on the Y axis.")]
    public float turnSpeed;

    private Rigidbody rb;
    private bool isGrounded;
    private int lives = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GroundCheck();

        Vector3 movement = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical")) * speed;

        Vector3 rotation = new Vector3(0.0f, Input.GetAxis("Mouse X") * turnSpeed * 10* Time.deltaTime, 0.0f);
        transform.Rotate(rotation, Space.Self);

        /*
        if (movement != Vector3.zero)
        {
            transform.forward = movement;
        }
        */

        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        rb.AddRelativeForce(movement * speed, ForceMode.VelocityChange);
    }

    void GroundCheck()
    {
        RaycastHit hit;
        float distanceTolerance = 1.0f;
        Vector3 direction = new Vector3(0, -1);

        if (Physics.Raycast(transform.position, direction, out hit, distanceTolerance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("SHOULD DIE");
            lives--;
            if (lives <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                lives++;
            }
        }
    }
}
