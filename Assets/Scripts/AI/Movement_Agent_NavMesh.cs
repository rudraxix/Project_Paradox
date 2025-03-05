using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement_Agent_NavMesh : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent = null)
        {
            Debug.LogError("NavMeshAgent component is missing on" + gameObject.name);
        }

        else if (!agent.isOnNavMesh)
        {
            Debug.LogError(gameObject.name + "is not on NavMeshSurface");
        }
    }

    // Update is called once per frame
    void Update()
    {
       if (target != null && agent.isOnNavMesh)
       {
        agent.SetDestination(target.position);
       } 
    }
}
