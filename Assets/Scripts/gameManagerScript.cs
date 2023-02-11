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
        if (player.isAlive == false || clock.isAlive == false || obstacles.isAlive == false || floor.isAlive == false)
        {
            restart_quit.SetActive(true);
        }
    }
}
