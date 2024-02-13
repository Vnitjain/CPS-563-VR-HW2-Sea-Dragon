using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraControllerPhoton : MonoBehaviourPunCallbacks
{
    void Start()
    {
        // Check if this is the local player's camera
        if (!photonView.IsMine)
        {
            // Disable control if this is not the local player's camera
            enabled = false;
        }
    }

    void Update()
    {
        if (!photonView.IsMine)
            return;

        // Camera control logic for the local player
        // Add your camera control code here
    }
}
