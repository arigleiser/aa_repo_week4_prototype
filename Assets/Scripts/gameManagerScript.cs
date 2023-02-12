using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameManagerScript : MonoBehaviour
{
    public GameObject restart_quit;
    public playerMovement playerScript;
    public timer clock;
    public loseIfTouchApple touchApple;
    //public loseIfTouchFloor floor;

    public TMP_Text disvar;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.isAlive == false)
        {
            gameOver();
        }

        else if (touchApple.isAlive == false)
        {
            restart_quit.SetActive(true);
        }
        // idk why this doesn't work- im trying to make it so that if it touches the floor, they lose
        //else if (floor.isAlive == false)
        //{
        //    restart_quit.SetActive(true);
        //}
    }

    public void gameOver()
    {
        disvar.text = "Game Over!";
        restart_quit.SetActive(true);
    }
}
