using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    float countdown = 60f;
    public TMP_Text disvar;
    // Start is called before the first frame update
    void Start()
    {
        disvar.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
        double b = System.Math.Round(countdown, 2);
        disvar.text = "Time Remaining: " + b.ToString();
        if (countdown < 0)
        {
            disvar.text = "Game Over!";
        }
    }
}
