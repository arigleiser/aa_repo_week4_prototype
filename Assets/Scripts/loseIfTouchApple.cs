using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseIfTouchApple : MonoBehaviour
{
    public bool isAlive;
    public AudioSource loseSound;
    // public playerMovement playerScript;
    GameObject trampoline;
    // public Collider2D coll;
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
        if (collision.gameObject.tag == "trampoline")
        {
            Destroy(gameObject);
        }
        else
        {
            isAlive = false;
        }
    }
}
