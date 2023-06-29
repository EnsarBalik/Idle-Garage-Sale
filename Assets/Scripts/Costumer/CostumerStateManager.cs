using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CostumerStateManager : MonoBehaviour
{
    private CostumerBaseState currentState;
    private readonly CostumerAssignmentState _assignmentState = new CostumerAssignmentState();

    private NavMeshAgent _navMeshAgent;

    [SerializeField] private Transform movePositionTransform;
    public List<Transform> taskLocations;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
        currentState = _assignmentState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        _navMeshAgent.destination = movePositionTransform.position;
    }

    public void SwitchState(CostumerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
    
}
