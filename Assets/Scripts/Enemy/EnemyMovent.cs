using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovent : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoints/positions to follow
    public float speed = 2.0f;   // Enemy movement speed
    private int currentWaypoint = 0;

    void Update()
    {
        // Check if there are waypoints to follow
        if (waypoints.Length == 0)
            return;

        // Calculate the direction to the current waypoint
        Vector3 direction = waypoints[currentWaypoint].position - transform.position;
        direction.Normalize();

        // Move the enemy towards the current waypoint
        transform.Translate(direction * speed * Time.deltaTime);

        // Check if the enemy has reached the current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
        {
            // Switch to the next waypoint
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }
}