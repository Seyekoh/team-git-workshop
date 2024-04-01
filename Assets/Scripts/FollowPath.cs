using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Diagnostics;

public class FollowPath : MonoBehaviour
{
    /// <summary>
    /// Set to the parent GameObject whose children are a sequence of waypoints
    /// </summary>
    public PathGuide path;

    public float speed;

    [SerializeField] Vector3 nextWaypoint;
    [SerializeField] int currentWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        path = path.GetComponent<PathGuide>();
        nextWaypoint = GetNextWaypoint();
        FaceTowards(nextWaypoint);
    }

    private Vector3 GetNextWaypoint()
    {
        return path.NextWaypoint;
    }

    // Update is called once per frame
    void Update()
    {
        handlePath();

        currentWaypoint = path.currentWaypointIndex;
    }

    private void FaceTowards(Vector3 nextWaypoint)
    {
        transform.rotation = Utils.FaceObject(transform.position, nextWaypoint, Utils.FacingDirection.Forward);
    }

    private void handlePath()
    {
        if (gameObject.name.Equals("Wagon") && path.currentWaypointIndex == 17)
        {
            return;
        }
        else if (gameObject.name.Equals("Wagon") && path.currentWaypointIndex == 29)
        {
            Destroy(gameObject);
        }

        if (gameObject.name.Equals("Guard (1)") && path.currentWaypointIndex == 38)
        {
            path.setNextWaypoint(19);
        }

        if (gameObject.name.Equals("Guard (2)") && path.currentWaypointIndex == 34)
        {
            path.setNextWaypoint(21);
        }

        if (gameObject.name.Equals("Guard (3)") && path.currentWaypointIndex == 39)
        {
            path.setNextWaypoint(12);
        }

        if (gameObject.name.Equals("Guard (4)") && path.currentWaypointIndex == 37)
        {
            path.setNextWaypoint(7);
        }

        if (transform.position == nextWaypoint)
        {
            nextWaypoint = GetNextWaypoint();

            FaceTowards(nextWaypoint);
        }
        transform.position = Vector3.MoveTowards(transform.position, nextWaypoint, Time.deltaTime * speed);
    }


}

