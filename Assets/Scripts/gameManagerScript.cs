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
        Debug.Log(playerScript.upspeed);
        if (playerScript.isAlive == false)
        {
            gameOver();
        }
    }

    public void gameOver()
    {
        playerScript.bgm.Stop();
        playerScript.upspeed = 0;
        playerScript.speed = 0;
        disvar.text = "Game Over!";
        restart_quit.SetActive(true);
        //Time.timeScale = 1;
    }

}
