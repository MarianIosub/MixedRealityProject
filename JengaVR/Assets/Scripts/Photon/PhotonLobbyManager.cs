using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using UnityEngine.SceneManagement;

public class PhotonLobbyManager : MonoBehaviourPunCallbacks
{
    public GameObject Player1Object;
    public GameObject Player2Object;
    public GameObject Player3Object;
    public GameObject Player4Object;

    public GameObject RoomCodeObject;
    public GameObject leftHand;
    public GameObject righthand;
    public GameObject leftHandController;
    public GameObject righthandController;

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

    private void CreatePlayer()
    {
        var lh = PhotonNetwork.Instantiate(leftHand.name, Vector3.zero, Quaternion.identity);
        lh.transform.SetParent(leftHandController.transform, false);
        var rh = PhotonNetwork.Instantiate(righthand.name, Vector3.zero, Quaternion.identity);
        rh.transform.SetParent(righthandController.transform, false);
    }

    public override void OnLeftRoom()
    {
        ClearNicknames();
        DisplayRoomCode();
        DisplayPlayersNicknames();
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

    public void ContinueToChooseTower()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("PlayScene");
        }
    }

    private void MoveToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}