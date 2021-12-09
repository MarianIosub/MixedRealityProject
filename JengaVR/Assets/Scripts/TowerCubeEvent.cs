using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TowerCubeEvent : MonoBehaviour
{
    Dictionary<int, Vector3> cubesPositions = new Dictionary<int, Vector3>();

    Queue<Vector3> positionQueue;
    Queue<Quaternion> rotationQueue;

    float cubeHeight = 0.029120269f;

    void MemorizeCubesPositions()
    {
        foreach(Transform child in this.gameObject.transform)
        {
            cubesPositions[child.gameObject.GetInstanceID()] = child.position;
        }
    }

    GameObject GetChildWhosePositionModified()
    {
        double maxDistance = 0;
        GameObject cubeWithMaxDistance = null;

        foreach(Transform child in this.gameObject.transform)
        {
            double distance = System.Math.Sqrt(System.Math.Pow((child.position.x - cubesPositions[child.gameObject.GetInstanceID()].x), 2) +
                System.Math.Pow(child.position.y - cubesPositions[child.gameObject.GetInstanceID()].y, 2) +
                System.Math.Pow(child.position.z - cubesPositions[child.gameObject.GetInstanceID()].z, 2));

            if(distance > maxDistance)
            {
                maxDistance = distance;
                cubeWithMaxDistance = child.gameObject;
            }
        }

        if(maxDistance >= 0.3)
        {
            return cubeWithMaxDistance;
        }
        return null;
    }

    void UpdateCubesPositions()
    {
        foreach (Transform child in this.gameObject.transform)
        {
            cubesPositions[child.gameObject.GetInstanceID()] = child.position;
        }
    }

    void InitializePositionQueue()
    {
        positionQueue = new Queue<Vector3>();
        Vector3 position;
        float lastCubeYPosition = this.gameObject.transform.GetChild(this.gameObject.transform.childCount - 1).position.y;

        for(int i=0; i<6; i++)
        {
            position = this.gameObject.transform.GetChild(i).position;
            position.y = lastCubeYPosition + cubeHeight;
            positionQueue.Enqueue(position);
        }
    }

    void InitializeRotationQueue()
    {
        rotationQueue = new Queue<Quaternion>();

        for (int i = 0; i < 6; i++)
        {
            rotationQueue.Enqueue(this.gameObject.transform.GetChild(i).rotation);
        }
    }

    void Start()
    {
        MemorizeCubesPositions();

        InitializePositionQueue();
        InitializeRotationQueue();
    }

    void Update()
    {
        if(Input.GetKeyUp("g"))
        {
            GameObject modifiedChild = GetChildWhosePositionModified();

            if(modifiedChild != null)
            {
                Quaternion rotation = rotationQueue.Dequeue();
                Vector3 position = positionQueue.Dequeue();

                modifiedChild.transform.rotation = rotation;
                modifiedChild.transform.position = position;

                rotationQueue.Enqueue(rotation);

                position.y = position.y + cubeHeight;
                positionQueue.Enqueue(position);

                UpdateCubesPositions();
            }
        }
    }
}
