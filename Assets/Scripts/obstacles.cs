using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    // public Camera cam;
    public GameObject applePrefab;
    // float countdown = 6.5f;
    public AudioSource collissionSound;
    public bool isAlive;

    private void Start()
    {
        Instantiate(applePrefab, new Vector3(1, 70, 0), Quaternion.identity);
        Instantiate(applePrefab, new Vector3(-5, 65, 0), Quaternion.identity);
        Instantiate(applePrefab, new Vector3(-4, 60, 0), Quaternion.identity);
        Instantiate(applePrefab, new Vector3(4, 56, 0), Quaternion.identity);
        Instantiate(applePrefab, new Vector3(-9, 52, 0), Quaternion.identity);
        Instantiate(applePrefab, new Vector3(-10, 47, 0), Quaternion.identity);
        Instantiate(applePrefab, new Vector3(12, 41, 0), Quaternion.identity);
        Instantiate(applePrefab, new Vector3(10, 34, 0), Quaternion.identity);
        Instantiate(applePrefab, new Vector3(-10, 26, 0), Quaternion.identity);
        Instantiate(applePrefab, new Vector3(0, 17, 0), Quaternion.identity);
        Instantiate(applePrefab, new Vector3(1, 7, 0), Quaternion.identity);
        Instantiate(applePrefab, new Vector3(3, 8, 0), Quaternion.identity);
        Instantiate(applePrefab, new Vector3(0, 30, 0), Quaternion.identity);
        Instantiate(applePrefab, new Vector3(0, 62, 0), Quaternion.identity);
        isAlive = true;
    }

    private void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collissionSound.Play();
        isAlive = false;
    }
}
