using System.IO;
using System.Linq;
using UnityEngine;

public class HoverObject : MonoBehaviour
{
    // Start is called before the first frame update
    private Material oldMat;
    public Material hoverMatRed, hoverMatGreen, hoverMatBlue;

    public void HoverOver()
    {
        var settings = File.ReadLines("Assets/Settings/settings.txt");
        switch (settings.ElementAt(1).Split("=")[1])
        {
            case "0":
                oldMat = GetComponent<MeshRenderer>().material;
                GetComponent<MeshRenderer>().material = hoverMatRed;
                break;
            case "1":
                oldMat = GetComponent<MeshRenderer>().material;
                GetComponent<MeshRenderer>().material = hoverMatGreen;
                break;
            case "2":
                oldMat = GetComponent<MeshRenderer>().material;
                GetComponent<MeshRenderer>().material = hoverMatBlue;
                break;
        }
    }

    public void HoverEnd()
    {
        GetComponent<MeshRenderer>().material = oldMat;
    }
}