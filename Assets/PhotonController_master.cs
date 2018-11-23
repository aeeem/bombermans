using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Photon.Pun;
using Photon.Realtime;

using UnityEngine.UI;
public class PhotonController_master : MonoBehaviourPunCallbacks {

    public static PhotonController_master controller;
    #region MonoBehaviourPunCallbacks callback
    public string versionName = "v0.1";
    // Use this for initialization
    public Text status;

    private void Awake()
    {

        controller = this;

    }

    public override void OnConnectedToMaster()
    {
        status.text = "connected to server, try to join lobby...";
        PhotonNetwork.JoinLobby();
        
    }

    public override void OnJoinedLobby()
    {
        status.text = "loby joined, lets see is there any room out there";
        PhotonNetwork.JoinRandomRoom();
    }

    private void Start()
    {
        
    }
    
    
    public void Plays() {
        Connect();
    }

    public void Connect()
    {
        
        PhotonNetwork.GameVersion = versionName;
        PhotonNetwork.ConnectUsingSettings();
        
        
 
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        status.text = "no room find! lets make one!";

        OnCreateroom();

    }


    public void OnCreateroom() {
        int randomRoom = Random.Range(0, 1000);
        RoomOptions roomops = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = 2
        };
        PhotonNetwork.CreateRoom("Room" + randomRoom, roomops);
    }

    public override void OnCreatedRoom()
    {
        status.text = PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log(message);
    }




    #endregion
}