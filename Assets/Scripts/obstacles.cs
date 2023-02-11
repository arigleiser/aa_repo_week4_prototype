using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    public GameObject obstacle;
    public static float spawnTime;
    public float decrease;
    public float increment;
    public float timerOne;
    public float timerTwo;
    public float range;
    public AudioSource collissionSound;
    public bool isAlive;

    private void Start()
    {
        spawnTime = 0.6f;
        timerOne = 0;
        timerTwo = 0;
        isAlive = true;
    }

    private void Update()
    {
        if (timerTwo > decrease)
        {
            if (spawnTime > 0.25)
            {
                spawnTime -= increment;
            }
            timerTwo = 0;
        }

        if (timerOne > spawnTime)
        {
            GameObject newObstacle = Instantiate(obstacle);
            newObstacle.transform.position = new Vector3(0, 8, 0);
            newObstacle.transform.position += new Vector3(Random.Range(-range, range), 0, 0);
            timerOne = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collissionSound.Play();
        isAlive = false;
    }
}
