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
        var tower = Instantiate(towerPrefab, new Vector3(0, 0.49f, -0.2f), Quaternion.identity);

        for (int i = 0; i < 54; i++)
        {
            var settings = File.ReadLines("Assets/Settings/settings.txt");
            switch (settings.ElementAt(1).Split("=")[1])
            {
                case "0":
                    tower.GetChild(i).GetComponent<MeshRenderer>().material = oakMaterial;
                    break;
                case "1":
                    tower.GetChild(i).GetComponent<MeshRenderer>().material = pineMaterial;
                    break;
                case "2":
                    tower.GetChild(i).GetComponent<MeshRenderer>().material = mahagonyMaterial;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}