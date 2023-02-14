using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlesOnCollission : MonoBehaviour
{
    public AudioSource boing;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            boing.time = 0.22f;
            boing.Play();
        }
        
    }
}
