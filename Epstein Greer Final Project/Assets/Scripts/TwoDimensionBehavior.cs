using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TwoDimensionBehavior : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 5.0f;
    //public LayerMask groundLayeri;
    public BoxCollider2D groundCheck;

    private int lives = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = 0.0f;

        if (GroundCheck())
        {
            moveVertical = Input.GetAxis("Vertical");
        }

        gameObject.transform.Translate(moveHorizontal * speed * Time.deltaTime, moveVertical * jumpForce * Time.deltaTime, 0.0f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Hit something or someother stuff");

        if (col.gameObject.CompareTag("Enemy"))
        {
            lives--;
            if (lives <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                lives++;
            }
        }
    }

    private bool GroundCheck()
    {
        return true;   
    }
}
