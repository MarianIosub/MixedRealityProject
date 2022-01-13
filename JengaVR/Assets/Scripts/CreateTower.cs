using System.IO;
using System.Linq;
using Photon.Pun;
using UnityEngine;

public class CreateTower : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform towerPrefab;
    public Transform spiralPrefab;
    public Material oakMaterial, pineMaterial, mahagonyMaterial;
    private Transform tower;

    /*
    private void AddEventListenersOnTowerCubes(GameObject tower)
    {
        foreach (Transform child in tower.transform)
        {
            child.gameObject.AddComponent<TowerCubeEvent>();
        }
    }*/
    void Start()
    {
        GameObject tower = null;
        if (PhotonNetwork.IsMasterClient)
        {
            var settings = File.ReadLines("Assets/Settings/settings.txt");
            var singleSetting = settings.ElementAt(1).Split("=")[1];
            var towerType = settings.ElementAt(4).Split("=")[1];
            if (towerType == "1")
            {
                tower = PhotonNetwork.Instantiate(spiralPrefab.name, new Vector3(0, 0.49f, -0.2f), Quaternion.identity);
            }
            else
            {
                tower = PhotonNetwork.Instantiate(towerPrefab.name, new Vector3(0, 0.49f, -0.2f), Quaternion.identity);
            }

            tower.GetComponent<PhotonRigidbodyView>().enabled = true;
            for (int i = 0; i < 54; i++)
            {
                // tower.transform.GetChild(i).GetComponent<Rigidbody>().mass = 5;
                switch (singleSetting)
                {
                    case "0":
                        tower.transform.GetChild(i).GetComponent<MeshRenderer>().material = oakMaterial;
                        break;
                    case "1":
                        tower.transform.GetChild(i).GetComponent<MeshRenderer>().material = pineMaterial;
                        break;
                    case "2":
                        tower.transform.GetChild(i).GetComponent<MeshRenderer>().material = mahagonyMaterial;
                        break;
                }
            }


            //AddEventListenersOnTowerCubes(tower);
            tower.AddComponent<TowerCubeEvent>();
            // this.GetComponent<PhotonView>().RPC("UpdateTower", RpcTarget.Others, tower);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    [PunRPC]
    public void UpdateTower(GameObject tower)
    {
        for (int i = 0; i < 54; i++)
        {
            var settings = File.ReadLines("Assets/Settings/settings.txt");
            switch (settings.ElementAt(1).Split("=")[1])
            {
                case "0":
                    tower.transform.GetChild(i).GetComponent<MeshRenderer>().material = oakMaterial;
                    break;
                case "1":
                    tower.transform.GetChild(i).GetComponent<MeshRenderer>().material = pineMaterial;
                    break;
                case "2":
                    tower.transform.GetChild(i).GetComponent<MeshRenderer>().material = mahagonyMaterial;
                    break;
            }
        }
    }
}