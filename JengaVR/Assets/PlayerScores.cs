using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class PlayerScores : MonoBehaviour
{
    public GameObject ScoreCanvas;
    public GameObject PlayerName;
    public int initialPositionY = 284;

    private void GeneratePlayerScores()
    {
        for (int i = 1; i <= PhotonNetwork.CurrentRoom.Players.Count; i++)
        {
            var playerName = Instantiate(PlayerName, new Vector3(-666, initialPositionY - (70 * i), 0), Quaternion.identity);
            playerName.transform.SetParent(ScoreCanvas.transform, false);
            playerName.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = PhotonNetwork.CurrentRoom.Players[i].NickName;
            playerName.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // SetInitialPlayerName(PhotonNetwork.LocalPlayer.NickName);
        PlayerName.SetActive(false);
        GeneratePlayerScores();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
