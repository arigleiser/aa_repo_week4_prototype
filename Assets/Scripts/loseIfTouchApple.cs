using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseIfTouchApple : MonoBehaviour
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
        if (collision.gameObject.tag == "Player")
        {
            loseSound.Play();
            isAlive = false;
        }
    }
}
