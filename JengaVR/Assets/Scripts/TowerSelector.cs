using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TowerSelector : MonoBehaviour
{
    // 0 -> Normal tower
    // 1 -> Spiral-shaped tower
    private int selectedTower = 0;

    public GameObject towerObject;
    public Sprite normalTowerSprite;
    public Sprite spiralTowerSprite;

    public void changeSelectedTower()
    {
        selectedTower = (selectedTower + 1) % 2;

        if(selectedTower == 0)
        {
            towerObject.GetComponent<Image>().sprite = normalTowerSprite;
        }
        else
        {
            towerObject.GetComponent<Image>().sprite = spiralTowerSprite;
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }
} 
