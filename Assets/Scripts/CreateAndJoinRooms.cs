using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField createInput;
    public InputField joinInput;

    //when you create a room - you automatically join it!
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
    }
    
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    //multiplayer scenes need to be loaded differently, this will load the scene for all the players... i think!
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.LoadLevel("Game");
    }
}
