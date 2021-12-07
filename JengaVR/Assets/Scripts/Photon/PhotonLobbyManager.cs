using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PhotonLobbyManager : MonoBehaviourPunCallbacks
{
    public GameObject Player1Object;
    public GameObject Player2Object;
    public GameObject Player3Object;
    public GameObject Player4Object;

    public GameObject RoomCodeObject;

    private void ClearNicknames()
    {
        Player1Object.GetComponent<UnityEngine.UI.Text>().text = "-";
        Player2Object.GetComponent<UnityEngine.UI.Text>().text = "-";
        Player3Object.GetComponent<UnityEngine.UI.Text>().text = "-";
        Player4Object.GetComponent<UnityEngine.UI.Text>().text = "-";
    }

    private void DisplayRoomCode()
    {
        RoomCodeObject.GetComponent<UnityEngine.UI.Text>().text = "Room Code: " + PhotonNetwork.CurrentRoom?.Name;
    }

    void Start()
    {
        DisplayRoomCode();
        ClearNicknames();
    }

    public override void OnJoinedRoom()
    {
        ClearNicknames();
        DisplayRoomCode();
        DisplayPlayersNicknames();
        CreatePlayer();
    }

    public override void OnPlayerEnteredRoom(Player player)
    {
        Debug.LogFormat("Player {0} joined the room", player.ToString());
        ClearNicknames();
        DisplayPlayersNicknames();
    }

    private void DisplayPlayersNicknames()
    {
        Debug.Log("Numele jucatorilor:");
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            Debug.Log(player.ToString());

            if (Player1Object.GetComponent<UnityEngine.UI.Text>().text == "-")
            {
                Player1Object.GetComponent<UnityEngine.UI.Text>().text = player.NickName;
            }
            else if (Player2Object.GetComponent<UnityEngine.UI.Text>().text == "-")
            {
                Player2Object.GetComponent<UnityEngine.UI.Text>().text = player.NickName;
            }
            else if (Player3Object.GetComponent<UnityEngine.UI.Text>().text == "-")
            {
                Player3Object.GetComponent<UnityEngine.UI.Text>().text = player.NickName;
            }
            else if (Player4Object.GetComponent<UnityEngine.UI.Text>().text == "-")
            {
                Player4Object.GetComponent<UnityEngine.UI.Text>().text = player.NickName;
            }
        }
    }

    public void CreatePlayer()
    {
        PhotonNetwork.Instantiate(Path.Combine("Assets", "Photon", "PhotonUnityNetworking", "Resources", "RightHand"),
            Vector3.zero, Quaternion.identity, 0);

        PhotonNetwork.Instantiate(Path.Combine("Assets", "Photon", "PhotonUnityNetworking", "Resources", "LeftHand"),
            Vector3.zero, Quaternion.identity, 0);
    }

    public override void OnPlayerLeftRoom(Player player)
    {
        if (player.NickName != PhotonNetwork.LocalPlayer.NickName)
        {
            Debug.LogFormat("Player {0} left the room", player.ToString());
            ClearNicknames();
            DisplayPlayersNicknames();
        }
    }

    public void LeaveJengaRoom()
    {
        PhotonNetwork.LeaveRoom();
        MoveToScene("ChooseLobbyScene");
    }

    private void MoveToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}