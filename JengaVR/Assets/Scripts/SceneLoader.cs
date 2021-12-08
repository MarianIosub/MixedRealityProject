using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void MoveToScene(string sceneName)
    {
        try
        {
            PhotonNetwork.LeaveRoom();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        SceneManager.LoadScene(sceneName);
    }

    public void CloseApplication()
    {
        Application.Quit();
    }
}