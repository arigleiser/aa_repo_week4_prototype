using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerScript : MonoBehaviour
{
    public GameObject restart_quit;
    public playerMovement player;
    public timer clock;
    public obstacles obstacles;
    public loseIfTouchFloor floor;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isAlive == false)
        {
            restart_quit.SetActive(true);
        }
        else if (clock.isAlive == false)
        {
            restart_quit.SetActive(true);
        }
        //else if (obstacles.isAlive == false)
        //{
        //    restart_quit.SetActive(true);
        //}
        // idk why this doesn't work- im trying to make it so that if it touches the floor, they lose
        //else if (floor.isAlive == false)
        //{
        //    restart_quit.SetActive(true);
        //}
    }
}
