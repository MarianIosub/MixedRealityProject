using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PhotonLobbyCreator : MonoBehaviourPunCallbacks
{
    string PlayerNickname = "";

    public void SetPlayerNickname(string nickname)
    {
        this.PlayerNickname = nickname.Trim(' ');
        Debug.LogFormat("Am setat numele {0} player-ului", PlayerNickname);
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

    public void CreateJengaRoom()
    {
        if (PlayerNickname.Length == 0)
        {
            PlayerNickname = "NoName";
        }

        PhotonNetwork.LocalPlayer.NickName = PlayerNickname;

        PhotonNetwork.CreateRoom(GenerateRoomCode(), new RoomOptions()
        {
            MaxPlayers = 4,
            IsVisible = true,
            IsOpen = true
        });

        PhotonNetwork.LoadLevel("LobbyScene");
    }

    public void JoinJengaRoom()
    {
        if (PlayerNickname.Length == 0)
        {
            PlayerNickname = "NoName";
        }

        PhotonNetwork.LocalPlayer.NickName = PlayerNickname;

        PhotonNetwork.LoadLevel("JoinLobbyScene");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("S-a creat room.");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Am intrat in room.");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogWarningFormat("A esuat create room. {0}", message);
    }

    private void MoveToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}