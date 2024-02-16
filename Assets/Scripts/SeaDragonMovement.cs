using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SeaDragonMovement : MonoBehaviourPunCallbacks
{
    Animator dragonAnimator;

    void Start()
    {
        dragonAnimator = GetComponent<Animator>();
        if (!photonView.IsMine)
        {
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
        FlyUpdates();
    }

    void FlyUpdates()
    {
        dragonAnimator.SetBool("isCapsLockOn", SeaDragonMain.isCapsLockOn);
    }

    void MovementUpdates()
    {
        if (!photonView.IsMine)
            return;
        dragonAnimator.SetBool("isWalkingVerticalForward", SeaDragonMain.verticalInput > 0);
        dragonAnimator.SetBool("isWalkingVerticalBack", SeaDragonMain.verticalInput < 0);
        dragonAnimator.SetBool("isWalkingHorizontalLeft", SeaDragonMain.horizontalInput < 0);
        dragonAnimator.SetBool("isWalkingHorizontalRight", SeaDragonMain.horizontalInput > 0);
        dragonAnimator.SetBool("isShiftPressed", SeaDragonMain.shiftPressed);
    }

    void JumpUpdates()
    {
        if (!photonView.IsMine)
            return;
        dragonAnimator.SetBool("isJumpPressed", SeaDragonMain.isJumpKeyPressed);
    }

    void AttackUpdates()
    {
        if (!photonView.IsMine)
            return;
        dragonAnimator.SetBool("isAttack1Pressed", SeaDragonMain.isFire1Pressed);
    }
}
