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

    private Dictionary<string, int> scores = new Dictionary<string, int>();

    private void GeneratePlayerScores()
    {
        for (int i = 1; i <= PhotonNetwork.CurrentRoom.Players.Count; i++)
        {
            if (!scores.ContainsKey(PhotonNetwork.CurrentRoom.Players[i].UserId)) {
                scores.Add(PhotonNetwork.CurrentRoom.Players[i].UserId, 0);
            }

            var playerName = Instantiate(PlayerName, new Vector3(-666, initialPositionY - (70 * i), 0), Quaternion.identity);
            playerName.transform.SetParent(ScoreCanvas.transform, false);
            playerName.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = PhotonNetwork.CurrentRoom.Players[i].NickName + " - " + scores[PhotonNetwork.CurrentRoom.Players[i].UserId];
            playerName.SetActive(true);
        }
    }

    public void IncrementPlayerScore()
    {
        scores[PhotonNetwork.LocalPlayer.UserId] += 1;
        GeneratePlayerScores();
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
