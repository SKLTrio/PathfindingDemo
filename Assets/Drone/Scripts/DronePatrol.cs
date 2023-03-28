using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DronePatrol : MonoBehaviour
{
    NavMeshAgent Nav_Mesh_Agent;
    [SerializeField] Transform Player_Object;

    GameObject Current_Waypoint;
    GameObject Previous_Waypoint;
    GameObject[] All_Waypoints;
    bool Is_Travelling;

    public float MaxDistance = 15f;

    // Start is called before the first frame update
    void Start()
    {
        Nav_Mesh_Agent = GetComponent<NavMeshAgent>();
        All_Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        Current_Waypoint = GetRandomWaypoint();
        SetDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (Is_Travelling && Nav_Mesh_Agent.remainingDistance <= 1f)
        {
            Is_Travelling = false;
            SetDestination();
        }

        LookForPlayer();
    }

    private void SetDestination()
    {
        Previous_Waypoint = Current_Waypoint;
        Current_Waypoint = GetRandomWaypoint();

        Vector3 Target_Vector = Current_Waypoint.transform.position;
        Nav_Mesh_Agent.SetDestination(Target_Vector);
        Is_Travelling = true;
    }

    public GameObject GetRandomWaypoint()
    {
        if (All_Waypoints.Length == 0)
        {
            return null;
        }

        else
        {
            int index = Random.Range(0, All_Waypoints.Length);
            return All_Waypoints[index];
        }

    }
    private void LookForPlayer()
    {
        Vector3 Drone_Pos = this.transform.position;
        Vector3 Player_Pos = Player_Object.transform.position;

        Vector3 Player_Distance = Player_Pos - Drone_Pos;

        if (Vector3.Distance(Player_Pos, Drone_Pos) < MaxDistance)
        {
            Nav_Mesh_Agent.SetDestination(Player_Pos);
            Is_Travelling = true;
        }
    }
}
