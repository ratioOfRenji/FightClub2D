using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparationState : BaseState
{
    public delegate void EnterPrepStage();
    public static event EnterPrepStage OnEnterPrepStage;

    public delegate void playerSentData();
    public static event EnterPrepStage OnplayerSentData;
    public override void EnterState(StateManager stateManager)
    {
        stateManager.timer.value = 15;
        OnEnterPrepStage();
    }

    public override void UpdateState(StateManager stateManager)
    {
        if (stateManager.timer.value <= 0)
        {
            stateManager.SwichState(stateManager.fightState);
        }
        if(stateManager.playersBool.value)
        {
            OnplayerSentData();
        }
        if(stateManager.playersBool.value && stateManager.opponentsBool.value)
        {
            stateManager.SwichState(stateManager.fightState);
        }
    }
}
