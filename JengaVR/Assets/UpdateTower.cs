using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class UpdateTower : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       photonView.RPC("UpdateTowerRpc", RpcTarget.Others, this);
    }

    [PunRPC]
    public void UpdateTowerRpc(GameObject otherTower)
    {
        Debug.Log("Called RPC for update");
        transform.position = otherTower.transform.position;
        transform.rotation = otherTower.transform.rotation;
        for (int i = 0; i < 54; i++)
        {
            transform.GetChild(i).transform.position = otherTower.transform.GetChild(i).transform.position;
            transform.GetChild(i).transform.rotation = otherTower.transform.GetChild(i).transform.rotation;
        }
    }
}
