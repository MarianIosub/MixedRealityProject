using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        var settings = File.ReadLines("Assets/Settings/settings.txt").ToList();
        if (selectedTower == 0)
        {
            towerObject.GetComponent<Image>().sprite = normalTowerSprite;
            settings[4] = "tower=0";
        }
        else
        {
            towerObject.GetComponent<Image>().sprite = spiralTowerSprite;
            settings[4] = "tower=1";
        }

        File.WriteAllLinesAsync("Assets/Settings/settings.txt", settings);
    }

    void Start()
    {
        var settings = File.ReadLines("Assets/Settings/settings.txt").ToList();
        settings[4] = "tower=0";
        File.WriteAllLinesAsync("Assets/Settings/settings.txt", settings);
    }

    void Update()
    {
    }
}