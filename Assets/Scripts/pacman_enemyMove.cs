using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class pacman_enemyMove : MonoBehaviour
{
   public Transform target; // цель, к которой будет двигаться призрак
    public float speed; // скорость движения призрака
    public float nextWaypointDistance = 0.1f; // расстояние до следующей точки пути

    Pathfinding pathfinding; // компонент поиска пути
    int currentWaypointIndex = 0; // индекс текущей точки пути
    bool reachedEndOfPath = false; // флаг, указывающий, достиг ли призрак конца пути

    Rigidbody2D rb; // компонент физики призрака

    void Start()
    {
        pathfinding = GetComponent<Pathfinding>();
        rb = GetComponent<Rigidbody2D>();

        // запускаем поиск пути
        pathfinding.FindPath(transform.position, target.position, OnPathFound);
    }

    void OnPathFound(Vector3[] waypoints, bool pathSuccessful)
    {
        if (pathSuccessful)
        {
            // сохраняем найденный путь и начинаем движение к цели
            currentWaypointIndex = 0;
            StartCoroutine(FollowPath(waypoints));
        }
    }

    IEnumerator FollowPath(Vector3[] waypoints)
    {
        // движение к следующей точке пути, пока не достигнут конец пути
        Vector3 currentWaypoint = waypoints[0];
        reachedEndOfPath = false;
        while (true)
        {
            if (transform.position == currentWaypoint)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    reachedEndOfPath = true;
                    yield break;
                }
                currentWaypoint = waypoints[currentWaypointIndex];
            }

            Vector3 direction = (currentWaypoint - transform.position).normalized;
            rb.velocity = direction * speed;

            yield return null;
        }
    }

    void Update()
    {
        // обновляем путь, если призрак достиг конца текущего пути
        if (reachedEndOfPath)
        {
            pathfinding.FindPath(transform.position, target.position, OnPathFound);
        }
    }
}
