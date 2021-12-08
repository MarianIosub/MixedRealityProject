using Photon.Pun;
using UnityEngine;

namespace Photon
{
    public class PlayerManager : MonoBehaviourPunCallbacks
    {
        public static GameObject LocalPlayerInstance;

        public void Awake()
        {
            if (photonView.IsMine)
            {
                PlayerManager.LocalPlayerInstance = this.gameObject;
            }
        }
    }
}