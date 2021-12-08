using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        tag = name;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Tag " + tag);
        Debug.Log("Name " + name);
    }
}