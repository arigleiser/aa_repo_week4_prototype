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

    //public AudioSource playRight;
    //public AudioSource playLeft;
    float angleRotated = 0;
    int numSpins = 0;
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

        Debug.Log("eulerAngles: " + transform.eulerAngles);
        Debug.Log("localEulerAngles: " + transform.localEulerAngles);
        numSpinText.text = "Number of Flips: " + (numSpins).ToString();


        if (isGrounded)
        {
            upspeed = 250f;
        }

        isGrounded = Physics2D.OverlapCircle(groundcheck.position, radius, groundlayer);
        movex = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movex * speed, rb.velocity.y);

       if (movex > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            //transform.rotation = Quaternion.Euler(new Vector2(0, transform.rotation.y + 0));

        }
        if (movex < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            //transform.rotation = Quaternion.Euler(new Vector2(0, transform.rotation.y + 180));
        }


        if (isGrounded && Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.velocity = Vector2.up * jumpforce;
        }


        if (isGrounded == false && Input.GetKey(KeyCode.RightArrow))
        {
            //playRight.Play();
            transform.Translate(Vector3.right * Time.deltaTime * 10, Space.World);
            
        }

        if (isGrounded == false && Input.GetKey(KeyCode.LeftArrow))
        {
            //playLeft.Play();
            transform.Translate(Vector3.left * Time.deltaTime * 10, Space.World);
        }


        if (Input.GetKey(KeyCode.Space))
        {
            spin();                   //new control: HOLD space key to rotate
        }


        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            spin();
            numSpins += 1;
        }*/





        if (gameObject.transform.position.y < -0.8400002)
        {
            isAlive = false;
            loose.Play();
        }

        if (gameObject.transform.position.y <= 1 && (gameObject.transform.eulerAngles.z > 40 && gameObject.transform.eulerAngles.z < 320))
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
            /*if (numSpins != 1 && numSpins / 2 != 0)
            {
                isAlive = false;
                loose.Play();
            }*/

            if(angleRotated >= 320)
            {
                numSpins++;
            }
            angleRotated = 0;
        }
    }


    private void spin()
    {
        if(transform.localScale.x == 1)
        {
            transform.eulerAngles += Vector3.forward * -200 * Time.deltaTime;
           
        }
        else
        {
            transform.eulerAngles += Vector3.forward * 200 * Time.deltaTime;
        }

        angleRotated += 400 * Time.deltaTime;
        

        if (angleRotated >= 360)
        {
            numSpins++;
            angleRotated = 0;
        }


        //gameObject.transform.rotation = Quaternion.Euler(Vector3.forward * -50/* * Time.deltaTime*/);

    }

    /*private void spin()
    {
        // spin
        // numSpins += 1;
        transform.Rotate(Vector3.forward * -90);
        numSpinText.text = "Number of Flips: " + (numSpins / 2).ToString();
    }*/
}
