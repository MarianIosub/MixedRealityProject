using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PhotonLobbyJoiner : MonoBehaviourPunCallbacks
{
    string LobbyCode = "";

    public void SetLobbyCode(string lobbyCode)
    {
        this.LobbyCode = lobbyCode.Trim();
        Debug.LogFormat("Am lobby code-ul {0}", LobbyCode);
    }

    private string GenerateRoomCode()
    {
        string chars = "0123456789";
        var random = new System.Random();
        string code = "";

        for (int i = 0; i < 6; i++)
        {
            char ch = chars[random.Next(10)];
            code += ch;
        }

        return code;
    }

    public void JoinJengaRoom()
    {
        if(LobbyCode.Length == 0)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.JoinRoom(LobbyCode);
        }
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room.");
        MoveToScene("LobbyScene");
    }

    public override void OnJoinRoomFailed(short returncode, string message)
    {
        Debug.Log("Join room a esuat.");

        PhotonNetwork.CreateRoom(GenerateRoomCode(), new RoomOptions()
        {
            MaxPlayers = 4,
            IsVisible = true,
            IsOpen = true
        });

        MoveToScene("LobbyScene");
    }
    
    public override void OnJoinRandomFailed(short returncode, string message)
    {
        Debug.Log("Join random room a esuat.");

        PhotonNetwork.CreateRoom(GenerateRoomCode(), new RoomOptions()
        {
            MaxPlayers = 4,
            IsVisible = true,
            IsOpen = true
        });

        MoveToScene("LobbyScene");
    }

    private void MoveToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
