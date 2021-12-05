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
        this.PlayerNickname = nickname.Trim();
        Debug.LogFormat("Am setat numele {0} player-ului", PlayerNickname);
    }

    public void CreateJengaRoom()
    {
        if(PlayerNickname.Length == 0)
        {
            PlayerNickname = "NoName";
        }

        PhotonNetwork.LocalPlayer.NickName = PlayerNickname;


        // Random generated digits code + display
        PhotonNetwork.CreateRoom("testroom", new RoomOptions()
        {
            MaxPlayers = 4,
            IsVisible = true,
            IsOpen = true
        });

        MoveToScene("LobbyScene");
    }

    public void JoinJengaRoom()
    {
        if (PlayerNickname.Length == 0)
        {
            PlayerNickname = "NoName";
        }

        PhotonNetwork.LocalPlayer.NickName = PlayerNickname;

        MoveToScene("JoinLobbyScene");
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
