﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreate : MonoBehaviour
{
    public GameObject wallObject;
    public GameObject pointParent;
    public GameObject wallParent;

    private Transform[] wallPoints;
    private wallTransform[] wallObjects;
    public float drawWallThreshold = 0.1f;
    public float width = 1;
    public float height = 10;
    //public int wallCount = 0;

    //public float magnitude;
    private void OnDrawGizmos()
    {
        wallPoints = pointParent.GetComponentsInChildren<Transform>();
        wallObjects = wallParent.GetComponentsInChildren<wallTransform>();
        
        for (int i = 2; i < wallPoints.Length; ++i)
        {
            Vector3 wallLine = wallPoints[i].position - wallPoints[i - 1].position;
            if (wallLine.magnitude > drawWallThreshold && wallObjects.Length > i-2)
            {
                Vector3 wallPosition = wallPoints[i - 1].position + 0.5f * wallLine;
                wallPosition.y += 0.5f * height;
                Quaternion wallRotation = Quaternion.Euler(0, Mathf.Atan2(-wallLine.z, wallLine.x) * 180 / Mathf.PI, 0);
                //float theta = Mathf.Atan2(wallLine.y, wallLine.x);
                //float scaleFactor = Mathf.Abs(Mathf.Cos(theta) / Mathf.Cos(theta*0.5f));
                wallObjects[i - 2].changeTransForm(wallPosition, wallRotation, wallLine.magnitude, height, width);
            }
            else if (wallLine.magnitude > drawWallThreshold && wallObjects.Length <= i - 2)
            {
                Vector3 wallPosition = wallPoints[i].position + 0.5f * wallLine;
                wallPosition.y += 0.5f * height;
                Quaternion wallRotation = Quaternion.Euler(0, Mathf.Atan2(-wallLine.z , wallLine.x)*180/Mathf.PI, 0);
                Instantiate(wallObject, wallPosition, wallRotation, wallParent.transform);
            }
        }

        foreach (Transform obj in wallPoints)
        {
           // Gizmos.DrawWireSphere(obj.position, 1);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

