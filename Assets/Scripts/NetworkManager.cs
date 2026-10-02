using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEditor.Build.Content;
using System.Collections;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public int maxPlayers = 10;
    //instance
    public static NetworkManager instance;

    void Awake()
    {
        instance = this;
     //   DontDestroyOnLoad(gameObject); 
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //connect to the master server
        PhotonNetwork.ConnectUsingSettings();
    }
public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    //creates a new room of the requested room name
    public void CreateRoom (string roomName)
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = (byte)maxPlayers;

        PhotonNetwork.CreateRoom(roomName, options);
    }

    //joins a rooms ofg the requested room name
    public void JoinRoom( string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    // changes the scene through Photons system
    [PunRPC]
    public void ChangeScene (string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }
    // called when we disconnec form the serrver
    public override void OnDisconnected(DisconnectCause cause)
    {
        PhotonNetwork.LoadLevel("Menu");
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
       // GameManager.instace.alivePLayers--;
        //GameUI.instance.UpdatePlayerInfoTest();

        if(PhotonNetwork.IsMasterClient)
        {
         //   GameManager.instance.CheckWinCondition();
        }
    }
    
}
