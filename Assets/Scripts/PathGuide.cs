using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This behaviour assumes all immediate-child game objects
/// are waypoints, in the order they appear in the hierarcy
/// </summary>
public class PathGuide : MonoBehaviour
{
    public int currentWaypointIndex = 0;

    public Vector3 NextWaypoint
    {
        get
        {
            Vector3 point = transform.GetChild(currentWaypointIndex).transform.position;
            currentWaypointIndex++;
            return point;
        }
    }

    public void setNextWaypoint(int newWaypointIndex)
    {
        currentWaypointIndex = newWaypointIndex;
    }
}
