using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CinemachineFollowsPlayers : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook freeLook;
    [SerializeField] private GameObject dragonGameObject;
    // Start is called before the first frame update
    void Start()
    {
        freeLook.LookAt = dragonGameObject.transform;
        freeLook.Follow = dragonGameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        freeLook.LookAt = dragonGameObject.transform;
        freeLook.Follow = dragonGameObject.transform;

        Debug.Log("free look : " + freeLook.LookAt.gameObject.name);
    }
}
