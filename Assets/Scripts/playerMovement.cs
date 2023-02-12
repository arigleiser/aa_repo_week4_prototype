using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private bool isSpinning;
    public AudioSource loose;

    public float maxRotateSpeed = 300;
    private float rotateSpeed;
    public float stamina = 100;
    public Slider staminaBar;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isAlive = true;
        isSpinning = false;
    }

    // Update is called once per frame
    void Update()
    {
        numSpinText.text = "Number of Flips: " + (numSpins).ToString();

        staminaBar.value = stamina;
        if(stamina < 100 && !isSpinning)
        {
            stamina += Time.deltaTime * 10;
        }
        rotateSpeed = maxRotateSpeed * (stamina / 100);


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
            isSpinning = true;
            spin();                   //new control: HOLD space key to rotate
        }
        else
        {
            isSpinning = false;
        }


        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            spin();
            numSpins += 1;
        }*/


        /*if (gameObject.transform.position.y < -0.8400002)
        {
            isAlive = false;
            loose.Play();
        }*/


        //checking lose conditions
        if (gameObject.transform.position.y <= 1 && (gameObject.transform.eulerAngles.z > 40 && gameObject.transform.eulerAngles.z < 320))
        {
            isAlive = false;
            // Application.Quit();
            // pause time
            //print("You lose!");
        }

        if(stamina == 0)
        {
            isAlive = false;
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
        else if (collision.gameObject.tag == "Apple")
        {
            // loose.Play();
            isAlive = false;
            loose.Play();
        }
    }


    private void spin()
    {
        if(transform.localScale.x == 1)
        {
            transform.eulerAngles += Vector3.forward * -rotateSpeed * Time.deltaTime;
           
        }
        else
        {
            transform.eulerAngles += Vector3.forward * rotateSpeed * Time.deltaTime;
        }

        angleRotated += 2* rotateSpeed * Time.deltaTime;

        if(stamina > 0)
        {
            stamina -= Time.deltaTime * 10;
        }

        if (angleRotated >= 360)
        {
            numSpins++;
            angleRotated = 0;
        }
    }

    /*private void spin()
    {
        // spin
        // numSpins += 1;
        transform.Rotate(Vector3.forward * -90);
        numSpinText.text = "Number of Flips: " + (numSpins / 2).ToString();
    }*/
}
