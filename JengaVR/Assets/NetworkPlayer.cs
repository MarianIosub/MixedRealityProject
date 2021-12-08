using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class NetworkPlayer : MonoBehaviour
{
    public Transform leftHand;
    public Transform rightHand;
    private PhotonView pv;
    public GameObject leftConroller;
    public GameObject rightController;

    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        leftConroller = GameObject.Find("LeftHand Controller");
        rightController = GameObject.Find("RightHand Controller");
        if (pv.IsMine)
        {
            leftHand.gameObject.SetActive(false);
            rightHand.gameObject.SetActive(false);

            MapPosition(leftHand, leftConroller.transform);
            MapPosition(rightHand, rightController.transform);
        }
    }

    void MapPosition(Transform target, Transform source)
    {

        var rotation = source.rotation;
        var position = source.position;
        Debug.Log("Position " + position);
        Debug.Log("Rotation " + rotation);
        target.position = position;
        target.rotation = rotation;
    }
}