using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class PhotonConnector : MonoBehaviourPunCallbacks
{
    string gameVersion = "1";

    public void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        DontDestroyOnLoad(this.gameObject);
    }

    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        Connect();
    }


    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = gameVersion;
    }
}
