using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHand : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject handPrefab;

    void Start()
    {
        Instantiate(handPrefab, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
    }
}