using System.IO;
using System.Linq;
using Photon.Pun;
using UnityEngine;

public class CreateHand : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject handPrefab;

    void Start()
    {
        PhotonNetwork.Instantiate(handPrefab.name, Vector3.zero, Quaternion.identity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}