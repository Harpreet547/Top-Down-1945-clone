using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public float minDistanceToReactWaypoint = 2;
    public Waypoint[] nextWaypointNode;

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, minDistanceToReactWaypoint);
    }
}
