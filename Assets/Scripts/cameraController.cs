using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour
{

    public GameObject player;        //Public variable to store a reference to the player game object


    private float offsetY;            //Private variable to store the offset distance between the player and camera
    //private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offsetY = transform.position.y - player.transform.position.y;
        //offset = transform.position- player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if (transform.position.y >= -1)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y + offsetY, transform.position.z);
            //transform.position = player.transform.position + offset;
        }

    }
}