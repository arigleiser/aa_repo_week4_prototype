using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    float countdown = 10f;
    public TMP_Text disvar;
    public bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
        disvar.text = "";
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
        double b = System.Math.Round(countdown, 0);
        disvar.text = "Seconds Remaining: " + b.ToString();
        if (countdown < 0)
        {
            disvar.text = "Game Over!";
            isAlive = false;
            // Application.Quit();
            // make reset and quit buttons appear
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
}
