using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SeaDragonMovement : MonoBehaviourPunCallbacks
{
    Animator dragonAnimator;
    Rigidbody dragonRigidBody;

    void Start()
    {
        dragonAnimator = GetComponent<Animator>();
        dragonRigidBody = GetComponent<Rigidbody>();

        dragonAnimator.SetBool("Stand", true);

        // Check if this is the local player's object
        if (!photonView.IsMine)
        {
            // Disable control if this is not the local player's object
            enabled = false;
        }
    }

    void Update()
    {
        if (!photonView.IsMine)
            return;

        JumpUpdates();
        MovementUpdates();
        AttackUpdates();
    }

    void MovementUpdates()
    {
        if (!photonView.IsMine)
            return;

        dragonAnimator.SetBool("Stand", dragonAnimator.GetFloat("Vertical") == 0 && dragonAnimator.GetFloat("Horizontal") == 0);
        dragonAnimator.SetFloat("Vertical", SeaDragonMain.verticalInput);
        dragonAnimator.SetFloat("Horizontal", SeaDragonMain.horizontalInput);
        dragonAnimator.SetBool("Swim", SeaDragonMain.inWater);
    }

    void JumpUpdates()
    {
        if (!photonView.IsMine)
            return;

        dragonAnimator.SetBool("Jump", SeaDragonMain.isJumpKeyPressed);
        dragonAnimator.SetBool("Grounded", SeaDragonMain.isGrounded);
    }

    void AttackUpdates()
    {
        if (!photonView.IsMine)
            return;

        if (SeaDragonMain.isFire1Pressed)
        {
            dragonAnimator.SetBool("Attack2", true);
            dragonAnimator.SetInteger("DragoInt", 2);
            dragonAnimator.SetBool("Attack1", true);
            dragonAnimator.SetInteger("ActionID", -1);
        }
        else
        {
            dragonAnimator.SetBool("Attack2", false);
            dragonAnimator.SetInteger("DragoInt", 0);
            dragonAnimator.SetBool("Attack1", false);
            dragonAnimator.SetInteger("ActionID", -1);
            dragonAnimator.SetBool("Attack1", false);
        }
    }
}
