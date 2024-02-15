using UnityEngine;
using Photon.Pun;

public class CameraControllerDragon : MonoBehaviourPunCallbacks
{
    public GameObject cameraHolder;
    public Vector3 offset;

    void Start()
    {
        if (!photonView.IsMine || photonView.Owner.ActorNumber != PhotonNetwork.LocalPlayer.ActorNumber)
        {
            // Disable control if this is not the local player's camera
            enabled = false;
        }
    }

    void Update()
    {
        if (!photonView.IsMine || photonView.Owner.ActorNumber != PhotonNetwork.LocalPlayer.ActorNumber)
            return;

        Debug.Log("My Actor Number :" + photonView.Owner.ActorNumber);
        Debug.Log("Other Actor Number :" + PhotonNetwork.LocalPlayer.ActorNumber);

        // Move the camera holder to follow the local player's dragon with the offset
        cameraHolder.transform.position = transform.position + offset;
    }
}