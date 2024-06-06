using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    public GameObject world;
    public float horizontalInput;
    public float verticalInput;
    public enum orientation { Left, Right, Up, Down };
    public orientation myorientation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput,Space.World);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput, Space.World);

        Tourne();
    }

    void Tourne()
    {
        if(horizontalInput > 0)
        {
            myorientation = orientation.Right;
        }
        else if (horizontalInput < 0)
        {
            myorientation = orientation.Left;
        }
        if(verticalInput > 0)
        {
            myorientation = orientation.Up;
        }
        else if (verticalInput < 0)
        {
            myorientation = orientation.Down;
        }

        if (myorientation == orientation.Right) {
            Quaternion right = Quaternion.Euler(0, 90, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, right, 0.1f );
        }
        else if (myorientation == orientation.Left)
        {
            Quaternion left = Quaternion.Euler(0, -90, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, left, 0.1f);
        }
        else if (myorientation == orientation.Up)
        {
            Quaternion up = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, up, 0.1f);
        }
        else if (myorientation == orientation.Down)
        {
            Quaternion down = Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, down, 0.1f);
        }
    }
}


