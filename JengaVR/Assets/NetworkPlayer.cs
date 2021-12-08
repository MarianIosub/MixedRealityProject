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

    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pv.IsMine)
        {
            leftHand.gameObject.SetActive(false);
            rightHand.gameObject.SetActive(false);

            MapPosition(leftHand, XRNode.LeftHand);
            MapPosition(rightHand, XRNode.RightHand);
        }
    }

    void MapPosition(Transform target, XRNode node)
    {
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);
        // var rotation = InputTracking.GetLocalRotation(node);
        // var position = InputTracking.GetLocalPosition(node);
        Debug.Log("Position " + position);
        Debug.Log("Rotation " + rotation);
        target.position = position;
        target.rotation = rotation;
    }
}