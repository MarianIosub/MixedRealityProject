using System.IO;
using System.Linq;
using Photon.Pun;
using UnityEngine;

public class CreateTower : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform towerPrefab;
    public Material oakMaterial, pineMaterial, mahagonyMaterial;

    void Start()
    {
        GameObject tower = null;
        if (PhotonNetwork.IsMasterClient)
        {
            tower = PhotonNetwork.Instantiate(towerPrefab.name, new Vector3(0, 0.49f, -0.2f), Quaternion.identity);


            if (tower is not null)
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

            this.GetComponent<PhotonView>().RPC("UpdateTower", RpcTarget.Others, tower);
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