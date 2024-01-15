using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] fallingPlatWaypoints;
    private int currentFallingPlatWaypointIndex = 0;
    [SerializeField] private float speed = 4f;
    void Update()
    {
        if (Vector2.Distance(fallingPlatWaypoints[currentFallingPlatWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentFallingPlatWaypointIndex++;
            if (currentFallingPlatWaypointIndex >= fallingPlatWaypoints.Length)
            {
                currentFallingPlatWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position,
            fallingPlatWaypoints[currentFallingPlatWaypointIndex].gameObject.transform.position, Time.deltaTime * speed);
    }
}
