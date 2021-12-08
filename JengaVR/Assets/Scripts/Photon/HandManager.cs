using System.IO;
using System.Linq;
using Photon.Pun;
using UnityEngine;

public class HandManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public GameObject handPrefab;
    public static GameObject LocalPlayerInstance;

    public void Awake()
    {
        if (photonView.IsMine)
        {
            LocalPlayerInstance = this.gameObject;
        }
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}