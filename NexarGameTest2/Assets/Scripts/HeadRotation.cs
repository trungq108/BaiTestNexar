using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HeadRotation : MonoBehaviour
{
    public Transform[] points;
    public float rotationSpeed = 5f;
    
    private void Update()
    {
        Transform nearestPoint = GetNearestPoint();

        transform.localRotation = Quaternion.LookRotation(nearestPoint.position);
        
    }

    private Transform GetNearestPoint()
    {
        Transform nearestPoint = points[0];
        float shortestDistance = Vector3.Distance(transform.position, nearestPoint.position);

        for (int i = 1; i < points.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, points[i].position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestPoint = points[i];
            }
        }

        return nearestPoint;
    }
}