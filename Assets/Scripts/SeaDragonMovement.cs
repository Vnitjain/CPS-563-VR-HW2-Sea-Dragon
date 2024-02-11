using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SeaDragonMovement : MonoBehaviour
{
    Animator dragonAnimator;
    Rigidbody dragonRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        dragonAnimator = GetComponent<Animator>();
        dragonRigidBody = GetComponent<Rigidbody>();

        dragonAnimator.SetBool("Stand", true);
    }

    // Update is called once per frame
    void Update()
    {
        JumpUpdates();
        MovementUpdates();
        AttackUpdates();
    }
    void MovementUpdates()
    {
        dragonAnimator.SetBool("Stand", dragonAnimator.GetFloat("Vertical") == 0 && dragonAnimator.GetFloat("Horizontal") == 0);
        dragonAnimator.SetFloat("Vertical", SeaDragonMain.verticalInput);
        dragonAnimator.SetFloat("Horizontal", SeaDragonMain.horizontalInput);
    }
    void JumpUpdates()
    {
        dragonAnimator.SetBool("Jump", SeaDragonMain.isJumpKeyPressed);
        dragonAnimator.SetBool("Grounded", SeaDragonMain.isGrounded);
    }
    void AttackUpdates()
    {
        if (SeaDragonMain.isFire1Pressed)
        {
            dragonAnimator.SetBool("Attack2", true);
            dragonAnimator.SetInteger("DragoInt", 1);
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
