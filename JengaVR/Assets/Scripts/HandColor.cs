using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class HandColor : MonoBehaviour
{
    public Material hoverMatBlack, hoverMatBlue;
    // Start is called before the first frame update

    void Start()
    {
        var settings = File.ReadLines("Assets/Settings/settings.txt");
        var type = settings.ElementAt(2).Split("=")[1];
        Debug.Log("Type " + type);
        switch (type)
        {
            case "1":
                GetComponent<MeshRenderer>().material = hoverMatBlack;
                break;
            case "2":
                GetComponent<MeshRenderer>().material = hoverMatBlue;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}