using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMoves : MonoBehaviour
{
    public int numTurns = 0;
    public float distanceFromGround = 0f;
    public float panSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        // we start with character on the floor
    }

    // Update is called once per frame
    void Update()
    {
        // every time the user presses the space button, the character rotates 360 degrees
        // we also add 1 to the amount of rotations they do
        if (Input.GetKeyDown(KeyCode.Space) && distanceFromGround > 0)
        {
            RotateByDegrees();
            numTurns += 1;
        }
        else if (distanceFromGround <= 0)
        {
            // we give an error message like - cannot spin when you are on the ground
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(new Vector3(-10f, 0f, 0f) * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(new Vector3(10f, 0f, 0f) * Time.deltaTime, Space.World);
        }
    }

    // function where character rotates
    void RotateByDegrees()
    {
        Vector3 rotationToAdd = new Vector3(0, 360, 0);
        transform.Rotate(rotationToAdd);
    }
}
