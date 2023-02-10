using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlesOnCollission : MonoBehaviour
{
    public AudioSource boing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        boing.Play();
    }
}
