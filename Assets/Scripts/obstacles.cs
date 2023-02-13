using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    public int ufoSpeed;
    public float Timer = 4f;
    public GameObject ufo;
    GameObject ufoClone;
    public loseIfTouchApple touchApple;
    public gameManagerScript gm;
    public AudioSource appleFallingSound;

    void Start()
    {

    }

    void Update()
    {
        //if (touchApple.isAlive == false)
        //{
        //    gm.gameOver();
        //}

        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            float spawnY = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y + 3.0f;
            ufoClone = Instantiate(ufo, new Vector3(Random.Range(-7, 7), spawnY, 0f), transform.rotation) as GameObject;
            //appleFallingSound.Play();
            Timer = 4f;
        }
    }
}
