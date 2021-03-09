using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnumNPCState
{
    Patrol,
    Seek
}


public class NPC : MonoBehaviour
{
    public Player player;
    public EnumNPCState state;

    public List<GameObject> points;
    NavMeshAgent agent;

  

    int index = 0;

    void Start()
    {
        state = EnumNPCState.Patrol;
        agent = GetComponent<NavMeshAgent>();
     
    }

    void Update()
    {
        

        switch (state)
        {
            case EnumNPCState.Patrol:
                agent.SetDestination(points[index].transform.position);

                if (Vector3.Distance(player.transform.position, transform.position) < 50)
                {
                    ChangeState(EnumNPCState.Seek);
                }
                break;
            case EnumNPCState.Seek:
                agent.SetDestination(player.transform.position);

                if (Vector3.Distance(player.transform.position, transform.position) > 10)
                {
                    ChangeState(EnumNPCState.Patrol);
                }
                break;
        }
    }

    void ChangeState(EnumNPCState newState)
    {
        switch (newState)
        {
            case EnumNPCState.Patrol:
                agent.speed = 2;
                break;
            case EnumNPCState.Seek:
                agent.speed = 4;
                break;
        }

        state = newState;
    }

    void ChangePoint()
    {
        index++;

        if (index >= points.Count)
        {
            index = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point"))
        {
            ChangePoint();
        }
    }

}
