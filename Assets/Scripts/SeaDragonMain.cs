using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

//photon id : caded358-3968-4e21-957b-4e6d80e49f95
public class SeaDragonMain : MonoBehaviourPunCallbacks
{
    private ProgressBar progressBar;
    public static bool isJumpKeyPressed;
    public static bool isFire1Pressed;
    public static bool shiftPressed;
    public static bool isQPressed;
    public static bool isEPressed;
    public static bool isEating;


    private Rigidbody dragonRigidBodyObject;
    public float jumpStrength;
    private bool jumpFlag;
    public static float verticalInput;
    public static float horizontalInput;
    PhotonView view;

    void Start()
    {
        progressBar = FindObjectOfType<ProgressBar>();
        dragonRigidBodyObject = GetComponent<Rigidbody>();
        isJumpKeyPressed = false;
        jumpFlag = true;
        shiftPressed = false;
        isQPressed = false;
        isEPressed = false;
        isEating = false;
        view = GetComponent<PhotonView>();

        if (!view.IsMine)
        {
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
        }
        if (Input.GetButton("Fire1"))
        {
            isFire1Pressed = true;
        }
        isEPressed = Input.GetKey(KeyCode.E);
        isQPressed = Input.GetKey(KeyCode.Q);
        shiftPressed = Input.GetKey(KeyCode.LeftShift);
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
        }
        else if (collision.gameObject.layer == 7) // Check if the collision is with a collectible object
        {
            Destroy(collision.gameObject);

            // Increment the progress bar only when colliding with a collectible object
            if (progressBar != null)
            {
                progressBar.IncrementProgress();
            }
        }
        if (collision.gameObject.layer == 6)
        {
            Vector3 gameObjectAttackDirection = collision.gameObject.transform.forward;
            Vector3 pushDirection = -gameObjectAttackDirection;
            float pushForce = 100f;
            Rigidbody gameObjectRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            gameObjectRigidBody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            Debug.Log("Hitt");
        }
    }
}