using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.IO;
using System.Threading.Tasks;

public class SaveData : MonoBehaviour
{
    public Dropdown pieceTextureDropdown;
    public Dropdown handColorDropdown;
    public Dropdown pieceSelectedDropdown;
    public Dropdown musicDropdown;

    public void SaveIntoJson()
    {
        List<string> settings = new List<string>();

        settings.Add("pieceTexture=" + pieceTextureDropdown.value);
        settings.Add("pieceSelected=" + pieceSelectedDropdown.value);
        settings.Add("handColor=" + handColorDropdown.value);
        settings.Add("music=" + musicDropdown.value);

        File.WriteAllLinesAsync("settings.txt", settings);
    }
}



