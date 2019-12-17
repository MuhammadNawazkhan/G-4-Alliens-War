using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G4_abc_MoveBaloon : MonoBehaviour
{
    public float speed = 5f;
    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        enabled = false;
        target = G4_Waypoints.points[0];

    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

    }
    void GetNextWaypoint()
    {
        if (wavepointIndex >= G4_Waypoints.points.Length - 1)
        {
            //Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = G4_Waypoints.points[wavepointIndex];
    }
    public void EnableUpdate(bool a)
    {
        enabled = a;
    }
}