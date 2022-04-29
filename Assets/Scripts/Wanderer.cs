using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wanderer : MonoBehaviour
{
    public float range;
    NavMeshAgent agent;
    Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            if (agent.hasPath)
            {
            }
            else
            {
                destination = transform.position + new Vector3(Random.Range(-range, range), 0f, Random.Range(-range, range));
                agent.SetDestination(destination);
            }
        }
    }
}
