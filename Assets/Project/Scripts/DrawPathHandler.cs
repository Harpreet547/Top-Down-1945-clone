using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPathHandler : MonoBehaviour{
    // public Transform transformRootObject;

    public bool showPath = false;

    Waypoint[] waypointNodes;

    void OnDrawGizmos() {
        if(!showPath) return;
        if(!transform) return;
        Gizmos.color = Color.blue;

        if (transform == null)
            return;

        //Get all Waypoints
        waypointNodes = transform.GetComponentsInChildren<Waypoint>();

        //Iterate the list
        foreach (Waypoint waypoint in waypointNodes) {
       
            foreach (Waypoint nextWayPoint in waypoint.nextWaypointNode) {
                if (nextWayPoint != null)
                    Gizmos.DrawLine(waypoint.transform.position, nextWayPoint.transform.position);
            }

        }
    }
}
