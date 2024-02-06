using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 


public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public InputField usernameInput;
    public Text buttonText;

    // Start is called before the first frame update
    
    // void Start()
    // {
    //     PhotonNetwork.ConnectUsingSettings();
    // }
    public void onClickConnect()
    {
        if (usernameInput.text.Length >= 1)
        {
            PhotonNetwork.NickName = usernameInput.text;
            buttonText.text = " Connecting....";
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    // Update is called once per frame
    public override void OnConnectedToMaster()
    {
        //PhotonNetwork.JoinLobby();
        SceneManager.LoadScene("Lobby");
    }
    // public override void OnJoinedLobby()
    // {
    //     SceneManager.LoadScene("Lobby");
    // }
}
