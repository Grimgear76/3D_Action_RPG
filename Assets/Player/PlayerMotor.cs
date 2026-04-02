using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Try to snap the agent to the nearest NavMesh point
        NavMeshHit hit;
        if (NavMesh.SamplePosition(transform.position, out hit, 5f, NavMesh.AllAreas))
        {
            agent.Warp(hit.position);
            Debug.Log("Agent warped to NavMesh at: " + hit.position);
        }
        else
        {
            Debug.LogError("No NavMesh found within 5 units of player! Check your bake.");
        }

        Debug.Log("Agent on NavMesh: " + agent.isOnNavMesh);
    }

    void Update()
    {

    }

    public void MoveToPoint(Vector3 point)
    {
        if (agent.isOnNavMesh)
        {
            agent.SetDestination(point);
        }
        else
        {
            Debug.LogError("Agent is not on NavMesh, cannot move.");
        }
    }
}