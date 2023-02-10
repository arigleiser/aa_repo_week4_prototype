using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;
    float movex;
    Rigidbody2D rb;
    public Transform groundcheck;
    bool isGrounded;
    public float radius;
    public LayerMask groundlayer;
    public float jumpforce;
    float upspeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            upspeed = 500f;
        }
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, radius, groundlayer);
        movex = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movex * speed, rb.velocity.y);

        if (movex > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector2(0, 0));
        }
        if (movex < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector2(0, 100));
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.velocity = Vector2.up * jumpforce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "trampoline" && isGrounded == false)
        {
            upspeed += 150f;
            if (upspeed >= 1400f)
            {
                upspeed = 1400f;
            }

            rb.AddForce(new Vector2(0, upspeed));
        }
    }
}
