using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//photon id : caded358-3968-4e21-957b-4e6d80e49f95
public class SeaDragonMain : MonoBehaviour
{
    public static bool isJumpKeyPressed;
    public static bool isFire1Pressed;
    public static bool isGrounded;
    private Rigidbody dragonRigidBodyObject;
    public float jumpStrength;
    private bool jumpFlag;
    public static float verticalInput;
    public static float horizontalInput;
    void Start()
    {
        dragonRigidBodyObject = GetComponent<Rigidbody>();
        isJumpKeyPressed = false;
        jumpFlag = true;
    }
    void Update()
    {
        if (Input.GetButton("Jump") && jumpFlag)
        {
            isJumpKeyPressed = true;
            jumpFlag = false;
            isGrounded = false;
        }
        if (Input.GetButton("Fire1"))
        {
            isFire1Pressed = true;
        }
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }
    void FixedUpdate()
    {
        dragonRigidBodyObject.velocity = new Vector3(horizontalInput * 10, dragonRigidBodyObject.velocity.y, verticalInput * 10);
        if (isJumpKeyPressed)
        {
            dragonRigidBodyObject.AddForce(Vector3.up * jumpStrength, ForceMode.VelocityChange);
            isJumpKeyPressed = false;
        }
        if (isFire1Pressed)
        {
            isFire1Pressed = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            jumpFlag = true;
            isGrounded = true;
        }
        if (collision.gameObject.layer == 7)
        {
            Destroy(collision.gameObject);
        }
    }
}
