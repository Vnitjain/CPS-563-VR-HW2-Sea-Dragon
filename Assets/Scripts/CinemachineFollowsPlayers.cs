using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CinemachineFollowsPlayers : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook freeLook;
    // Start is called before the first frame update
    void Start()
    {
        freeLook.LookAt = gameObject.transform;
        freeLook.Follow = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
