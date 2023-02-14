using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlesOnCollission : MonoBehaviour
{
    public AudioSource boing;
    public playerMovement playerScript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && playerScript.isAlive)
        {
            boing.time = 0.22f;
            boing.Play();
        }
        
    }
}
