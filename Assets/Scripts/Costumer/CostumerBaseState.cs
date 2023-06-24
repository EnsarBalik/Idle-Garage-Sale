using System.Threading.Tasks;
using UnityEngine;

public abstract class CostumerBaseState
{
    public abstract void EnterState(CostumerStateManager costumer);

    public abstract void UpdateState(CostumerStateManager costumer);

    public abstract void CompletedAssignment(CostumerStateManager costumer);

    public abstract void AssignTask(CostumerStateManager costumer);
}
