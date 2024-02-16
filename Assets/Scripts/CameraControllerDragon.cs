using UnityEngine;
using Photon.Pun;

public class CameraControllerDragon : MonoBehaviourPunCallbacks
{
    [SerializeField] Camera dragonCam;

    void Start()
    {
        if (!photonView.IsMine)
        {
            // Disable control if this is not the local player's camera
            Destroy(dragonCam);
        }
    }
}