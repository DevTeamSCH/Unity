using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolControl : MonoBehaviour
{
    // Start is called before the first frame update
    bool destInRange;
    NavMeshAgent agent;
    float walkRadius = 20;
    
    void Start()
    {
        destInRange = true;
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        destInRange = agent.remainingDistance <0.5;
        if(destInRange)
        {
            Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
            Vector3 finalPosition = hit.position;
            agent.SetDestination(finalPosition);
        }
    }
}
