using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTower : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform towerPrefab;
    public Material material1, material2, material3;

    void Start()
    {
        var tower = Instantiate(towerPrefab, new Vector3(0, 0.49f, -0.2f), Quaternion.identity);
        Debug.Log("Applied Material: " + material1.name);
        // Get the current material applied on the GameObject
        for (int i = 0; i < 54; i++)
        {
            MeshRenderer meshRenderer = tower.GetChild(i).GetComponent<MeshRenderer>();
            Material oldMaterial = meshRenderer.material;
            Debug.Log("Applied Material: " + oldMaterial.name);
            // Set the new material on the GameObject
            meshRenderer.material = material1;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}