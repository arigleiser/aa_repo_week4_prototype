using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlesOnCollission : MonoBehaviour
{
    public AudioSource boing;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        boing.Play();
    }
}
