using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    public Rigidbody myRB;
    public GameObject myTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (myTarget != null && Input.GetKeyDown(KeyCode.E))
        {
            myTarget.SetActive(false);
            //INVENTORY
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}