using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseIfTouchFloor : MonoBehaviour
{
    //public bool isAlive;
    public AudioSource loseSound;
    public playerMovement playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //loseSound.Play();
            playerScript.numHearts--;
        }
    }
}
