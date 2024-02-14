using UnityEngine;
using Photon.Pun;

public class CameraControllerDragon : MonoBehaviourPunCallbacks
{
    public GameObject cameraHolder;
    public Vector3 offset;

    void Start()
    {
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

        // Move the camera holder to follow the local player's dragon with the offset
        cameraHolder.transform.position = transform.position + offset;
    }
}
