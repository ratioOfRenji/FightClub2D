using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingState : BaseState
{
    public override void EnterState(StateManager stateManager)
    {
    }

    public override void UpdateState(StateManager stateManager)
    {
        if(stateManager.playersInRoom.value == 2)
        {
            stateManager.SwichState(stateManager.preparationState);
        }
    }
}
