using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceRotationfix : MonoBehaviour
{
    // Start is called before the first frame update
    public int frames = 120;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        frames -= 1;
        if (frames == 0)
        {
            for (int i = 0; i < 54; i++)
            {
                var piece = gameObject.transform.GetChild(i);
                var b = piece.GetComponent<Rigidbody>();
                b.constraints = RigidbodyConstraints.None;
            }
        }
    }
}