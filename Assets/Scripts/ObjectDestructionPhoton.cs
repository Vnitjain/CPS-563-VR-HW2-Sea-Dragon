using UnityEngine;
using Photon.Pun;
using System.Collections.Generic;

public class ObjectDestructionPhoton : MonoBehaviourPunCallbacks
{
    [SerializeField] private List<GameObject> currentGameObjects;
    void Start()
    {
        if (!photonView.IsMine)
        {
            for (int i = 0; i < currentGameObjects.Count; i++)
            {
                GameObject currentGameObject = currentGameObjects[i];
                if (currentGameObject != null)
                    Destroy(currentGameObject);
            }
        }
    }
}