using UnityEngine;
using UnityEngine.AI;

public class NavMeshMove : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField]
    private Transform bed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToBed()
    {
        agent.SetDestination(bed.position);
    }
}
