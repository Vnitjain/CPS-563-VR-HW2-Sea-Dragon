using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

//photon id : caded358-3968-4e21-957b-4e6d80e49f95
public class SeaDragonMain : MonoBehaviourPunCallbacks
{
    public static bool isJumpKeyPressed;
    public static bool isFire1Pressed;
    public static bool isGrounded;
    public static bool inWater;

    private Rigidbody dragonRigidBodyObject;
    public float jumpStrength;
    private bool jumpFlag;
    public static float verticalInput;
    public static float horizontalInput;
    PhotonView view;

    void Start()
    {
        dragonRigidBodyObject = GetComponent<Rigidbody>();
        isJumpKeyPressed = false;
        jumpFlag = true;
        inWater = false;
        view = GetComponent<PhotonView>();

        // Check if this is the local player's object
        if (!view.IsMine)
        {
            // Disable control if this is not the local player's object
            enabled = false;
        }
    }

    void Update()
    {
        if (!view.IsMine)
            return;

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
        if (!view.IsMine)
            return;

        dragonRigidBodyObject.velocity = new Vector3(horizontalInput * 100, dragonRigidBodyObject.velocity.y, verticalInput * 100);
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
            inWater = false;
        }
        if (collision.gameObject.layer == 7)
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.layer == 4)
        {
            inWater = true;
        }
    }
}
