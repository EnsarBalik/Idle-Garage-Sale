using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumerAssignmentState : CostumerBaseState
{
    public override void EnterState(CostumerStateManager costumer)
    {
        //todo Check new task
    }

    public override void UpdateState(CostumerStateManager costumer)
    {
        //todo go to task area
    }

    public override void CompletedAssignment(CostumerStateManager costumer)
    {
        //todo move away from the task area
    }

    public override void AssignTask(CostumerStateManager costumer)
    {
        //todo assign a task costumer
    }
}
