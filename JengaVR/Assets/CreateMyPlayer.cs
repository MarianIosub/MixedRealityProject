using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;

public class CreateMyPlayer : MonoBehaviour
{
    public PhotonView myPhotonView;

    // Start is called before the first frame update
    void Start()
    {
        var photonView = GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
            CreatePlayer();
        }
    }

    public void CreatePlayer()
    {
        PhotonNetwork.Instantiate(Path.Combine("Assets", "Photon", "PhotonUnityNetworking", "Resources", "RightHand"),
            Vector3.zero, Quaternion.identity, 0);

        PhotonNetwork.Instantiate(Path.Combine("Assets", "Photon", "PhotonUnityNetworking", "Resources", "LeftHand"),
            Vector3.zero, Quaternion.identity, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }
}