using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : BaseState
{
    public delegate void EnterFightStage();
    public static event EnterFightStage OnEnterGameOverStage;
    public override void EnterState(StateManager stateManager)
    {
    }

    public override void UpdateState(StateManager stateManager)
    {
    }
}
