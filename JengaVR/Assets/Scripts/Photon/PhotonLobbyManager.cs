using System.Collections;
using System.Collections.Generic;
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

    // OnDisconectedRoom -- display + check if playerlist.length > 0
}
