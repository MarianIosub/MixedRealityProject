using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class PhotonLobbyManager : MonoBehaviourPunCallbacks
{
    public GameObject Player1Object;
    public GameObject Player2Object;
    public GameObject Player3Object;
    public GameObject Player4Object;

    void Start()
    {
        Player1Object.GetComponent<UnityEngine.UI.Text>().text = "-";
        Player2Object.GetComponent<UnityEngine.UI.Text>().text = "-";
        Player3Object.GetComponent<UnityEngine.UI.Text>().text = "-";
        Player4Object.GetComponent<UnityEngine.UI.Text>().text = "-"; 
    }

    public override void OnJoinedRoom()
    {
        DisplayPlayersNicknames();
    }

    public override void OnPlayerEnteredRoom(Player player)
    {
        Debug.LogFormat("Player {0} joined the room", player.ToString());
        DisplayPlayersNicknames();
    }

    private void DisplayPlayersNicknames()
    {
        Debug.Log("Numele jucatorilor:");
        foreach(Player player in PhotonNetwork.PlayerList)
        {
            Debug.Log(player.ToString());

            if(Player1Object.GetComponent<UnityEngine.UI.Text>().text == "-")
            {
                Player1Object.GetComponent<UnityEngine.UI.Text>().text = player.NickName;
            }
            else if(Player2Object.GetComponent<UnityEngine.UI.Text>().text == "-")
            {
                Player2Object.GetComponent<UnityEngine.UI.Text>().text = player.NickName;
            }
            else if(Player3Object.GetComponent<UnityEngine.UI.Text>().text == "-")
            {
                Player3Object.GetComponent<UnityEngine.UI.Text>().text = player.NickName;
            }
            else if(Player4Object.GetComponent<UnityEngine.UI.Text>().text == "-")
            {
                Player4Object.GetComponent<UnityEngine.UI.Text>().text = player.NickName;
            }

        }
    }

    // OnDisconectedRoom -- display + check if playerlist.length > 0; if master, change lobby master
    public override void OnPlayerLeftRoom(Player player)
    {
        Debug.LogFormat("Player {0} left the room", player.ToString());
        if (player.IsMasterClient)
        {
            var players = PhotonNetwork.PlayerList;
            int numberOfPlayers = 0;
            foreach(Player dummy in players)
            {
                numberOfPlayers++;
            }

            if(numberOfPlayers > 0)
            {
                PhotonNetwork.SetMasterClient(players[0]);
            }
        }
    }
}
