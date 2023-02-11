using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseIfTouchFloor : MonoBehaviour
{
    public bool isAlive;
    public AudioSource loseSound;
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        loseSound.Play();
        isAlive = false;
    }
}
