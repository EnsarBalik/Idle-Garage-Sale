using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumerStateManager : MonoBehaviour
{
    private CostumerBaseState currentState;
    private readonly CostumerAssignmentState _assignmentState = new CostumerAssignmentState();

    public List<Transform> taskLocations;

    private void Start()
    {
        currentState = _assignmentState;
        
        currentState.EnterState(this);
    }

    public void SwitchState(CostumerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
    
}
