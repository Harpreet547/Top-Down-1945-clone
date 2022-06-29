using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FollowWaypoints : MonoBehaviour {

    protected Waypoint[] allWaypoints;
    protected Waypoint currentWaypoint;
    protected Vector3 targetPosition = Vector3.zero;

    protected void Awake() {
        allWaypoints = FindObjectsOfType<Waypoint>();
        currentWaypoint = FindClosestWaypoint();
    }

    protected void Update() {
        FollowWaypoint();
        // transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime * 0.1f);
    }

    void FollowWaypoint() {
        if(currentWaypoint == null) currentWaypoint = FindClosestWaypoint();

        if(currentWaypoint == null) return;
        targetPosition = currentWaypoint.transform.position;

        // store how close we are to the waypoint
        float distanceToWayPoint = (targetPosition - transform.position).magnitude;

        // Check if we are close enough to consider that we have reached the waypoint.
        if(distanceToWayPoint <= currentWaypoint.minDistanceToReactWaypoint) {
            // If we are close enough then follow to the next waypoint, if there are multiple waypoints then pick one at random.
            currentWaypoint = currentWaypoint.nextWaypointNode[Random.Range(0, currentWaypoint.nextWaypointNode.Length)];
        }
    }

    Waypoint FindClosestWaypoint() {
        return allWaypoints.OrderBy(t => Vector3.Distance(transform.position, t.transform.position)).FirstOrDefault();
    }

    void OnDrawGizmos() {
        if(currentWaypoint == null) return;

        Debug.DrawLine(transform.position, currentWaypoint.transform.position, Color.green);
    }
}
