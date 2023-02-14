using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    float countdown = 60f;
    public TMP_Text disvar;
    public playerMovement playerScript;
    public AudioSource clock;
    // Start is called before the first frame update
    void Start()
    {
        disvar.text = "";
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
            if (countdown >=15 && countdown <= 16 && playerScript.isAlive) 
            {
                clock.Play();
            }
        }
        double b = System.Math.Round(countdown, 0);
        disvar.text = "Seconds Remaining: " + b.ToString();
        if (countdown < 0)
        {
            //disvar.text = "Game Over!";
            playerScript.isAlive = false;
            clock.Stop();
            // Application.Quit();
            // make reset and quit buttons appear
        }
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
}
