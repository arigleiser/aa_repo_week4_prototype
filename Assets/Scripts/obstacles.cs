using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    // public GameObject obstacle;
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    public AudioSource collissionSound;
    public bool isAlive;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Update()
    {
        if (transform.position.y < screenBounds.y * 2)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collissionSound.Play();
        isAlive = false;
    }
}
