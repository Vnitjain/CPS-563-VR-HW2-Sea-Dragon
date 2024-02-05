using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            rb.velocity= new Vector3(0,5,0);
        }
        if (Input.GetKeyDown("up"))
        {
            rb.velocity= new Vector3(0,0,5);
        }
        if (Input.GetKeyDown("down"))
        {
            rb.velocity= new Vector3(0,0,-5);
        }
        if (Input.GetKeyDown("right"))
        {
            rb.velocity= new Vector3(5,0,0);
        }
        if (Input.GetKeyDown("left"))
        {
            rb.velocity= new Vector3(-5,0,0);
        }
    }
}
