using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public AudioSource playRight;
    public AudioSource playLeft;
    int numSpins = 1;
    public TMP_Text numSpinText;
    public bool isAlive;
    public AudioSource loose;

    public int stamina = 100;
    
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            upspeed = 250f;
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
            transform.rotation = Quaternion.Euler(new Vector2(0, 180));
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.velocity = Vector2.up * jumpforce;
        }
        if (isGrounded == false && Input.GetKey(KeyCode.RightArrow))
        {
            playRight.Play();
            this.transform.Translate(new Vector3(10f, 0f, 0f) * Time.deltaTime, Space.World);
        }
        if (isGrounded == false && Input.GetKey(KeyCode.RightArrow))
        {
            playLeft.Play();
            this.transform.Translate(new Vector3(-10f, 0f, 0f) * Time.deltaTime, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spin();
            numSpins += 1;
            Debug.Log("Num Spins: " + numSpins);
        }
        //else if (Input.GetKeyDown(KeyCode.Space) && gameObject.transform.position.y <= 1.5)
        //{
        //    numSpins += 1;
        //    Application.Quit();
        //    print("You lose!");
        //}

        if (gameObject.transform.position.y <= 0.66 && (gameObject.transform.rotation.z > 40 || gameObject.transform.rotation.z < -40))
        {
            // Application.Quit();
            // pause time
            isAlive = false;
            print("You lose!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "trampoline" && isGrounded == false)
        {
            upspeed += 100f;
            //if (upspeed >= 1400f)
            //{
            //    upspeed = 1400f;
            //}

            rb.AddForce(new Vector2(0, upspeed));
            if (numSpins != 1 && numSpins / 2 != 0)
            {
                isAlive = false;
                loose.Play();
            }
        }
    }

    private void spin()
    {
        // spin
        // numSpins += 1;
        transform.Rotate(Vector3.forward * -90);
        numSpinText.text = "Number of Flips: " + (numSpins / 2).ToString();
    }
}
