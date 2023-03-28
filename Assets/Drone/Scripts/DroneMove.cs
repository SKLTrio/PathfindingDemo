using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneMove : MonoBehaviour
{

    [SerializeField] Transform destination;
    NavMeshAgent Nav_Mesh_Agent;

    // Start is called before the first frame update
    void Start()
    {
        Nav_Mesh_Agent = GetComponent<NavMeshAgent>();
        if (Nav_Mesh_Agent == null)
        {
            Debug.LogError("The NavMeshComponent is not attatched to " + gameObject.name);
        }

        else
        {
            SetDestination();
        }
    }

    private void SetDestination()
    {
        if (destination != null)
        {
            Vector3 targetVector = destination.transform.position;
            Nav_Mesh_Agent.SetDestination(targetVector);
        }
    }
}
