using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

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

        File.WriteAllLinesAsync("Assets/Settings/settings.txt", settings);
    }
}



