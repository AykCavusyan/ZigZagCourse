using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed;
    Rigidbody rb;
    [SerializeField] GameObject newPlatform;

    bool started;
    public bool gameOver;
    bool grounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        grounded = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;
            }

            
            
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if (!Physics.Raycast(transform.position, Vector3.down, 100f) && grounded == true)
        {
            rb.velocity = new Vector3(0, -25f, 0);
            gameOver = true;
            Debug.Log("Game Over");
            
        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space working");
            
            Jump();
            
        }

    }

    void SwitchDirection()
    {
        if(rb.velocity.z > 0 && grounded == true)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0 && grounded == true)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    void Jump()
    {
        rb.AddForce(0,210,0);
        rb.useGravity = true;
        grounded = false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            rb.useGravity = false;
            grounded = true;

        }
    }
}
