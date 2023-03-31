using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pacman_enemyMove : MonoBehaviour
{
   
    public float moveSpeed = 2f;
    public Transform[] waypoints;

    private int currentWaypointIndex = 0;

    void Update()
    {
        // Check if we've reached the current waypoint
        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            // If we have, move to the next waypoint
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                // If we've reached the end of the waypoints, loop back to the start
                currentWaypointIndex = 0;
            }
        }

        // Move towards the current waypoint
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);
    }
}
