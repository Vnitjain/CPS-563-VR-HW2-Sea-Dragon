using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

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
    public static bool isDancing;


    private Rigidbody dragonRigidBodyObject;
    public float jumpStrength;
    private bool jumpFlag;
    public static float verticalInput;
    public static float horizontalInput;
    private int powerupCount;
    private TMP_Text WinText;
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
        isDancing = false;
        view = GetComponent<PhotonView>();
        powerupCount = 2;

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
        if (collision.gameObject.layer == 7) // Check if the collision is with a collectible object
        {
            isEating = true;
            powerupCount++;
            Destroy(collision.gameObject);
            Invoke("StopEating", 0.1f);
            if (powerupCount >= 4)
            {
                isDancing = true;
                WinText = GameObject.FindObjectOfType<TMP_Text>();
                WinText.text = "You Win!!!";
                Invoke("StopDancing", 2);
            }
            // Increment the progress bar only when colliding with a collectible object
            if (progressBar != null)
            {
                progressBar.IncrementProgress();
            }
        }
    }

    private void StopDancing()
    {
        isDancing = false;
    }
    private void StopEating()
    {
        isEating = false;
    }
}