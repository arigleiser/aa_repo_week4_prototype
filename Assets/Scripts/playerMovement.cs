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
    

    public float maxRotateSpeed = 300;
    private float rotateSpeed;
    public float stamina = 100;
    public Slider staminaBar;

    public int numHearts = 3;
    public GameObject heart1, heart2, heart3;

    public AudioSource lose;
    public AudioSource panting;
    public AudioSource scorePoint;
    public AudioSource bgm;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isAlive = true;
        isSpinning = false;
        bgm.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if(numHearts == 0)
        {
            isAlive = false;
        }

        numSpinText.text = "Number of Flips: " + (numSpins).ToString();

        staminaBar.value = stamina;
        if(stamina < 100 && !isSpinning)
        {
            stamina += Time.deltaTime * 20;
        }
        rotateSpeed = maxRotateSpeed * (stamina / 100);

        if (isAlive)
        {
            
            if(stamina < 90 && isAlive)
            {
                panting.volume = (140 - stamina) / 100;

            }
            else if(stamina >= 90 || !isAlive)
            {
                panting.volume = 0;
            }


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


            /*if (isGrounded && Input.GetKeyDown(KeyCode.DownArrow))
            {
                rb.velocity = Vector2.up * jumpforce;
            }*/


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
        /*if (gameObject.transform.position.y == 1 && (gameObject.transform.eulerAngles.z > 60 && gameObject.transform.eulerAngles.z < 300))
        {
            loseLife();
            // Application.Quit();
            // pause time
            //print("You lose!");
        }

        if(stamina == 0)
        {
            numHearts = 0;
        }*/

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "trampoline" && isGrounded == false && isAlive == true)
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
                scorePoint.Play();
            }
            angleRotated = 0;


            if (gameObject.transform.eulerAngles.z > 60 && gameObject.transform.eulerAngles.z < 300)
            {
                loseLife();             //collision detection
            }
            
        }
        else if (collision.gameObject.tag == "Apple")
        {
            loseLife();
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
            scorePoint.Play();
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

    public void loseLife()
    {
        lose.Play();

        if (numHearts == 3)
        {
            Destroy(heart3);
            numHearts--;
        }
        else if (numHearts == 2)
        {
            Destroy(heart2);
            numHearts--;
        }
        else if (numHearts == 1)
        {
            Destroy(heart1);
            numHearts--;
        }
    }

    
}
