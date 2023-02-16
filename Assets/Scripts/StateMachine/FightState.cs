using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightState : BaseState
{
    public delegate void EnterFightStage();
    public static event EnterFightStage OnEnterFightStage;

    public delegate void NextFightLoop();
    public static event NextFightLoop OnNextFightLoop;
    public override void EnterState(StateManager stateManager)
    {
        OnEnterFightStage();
    }

    public override void UpdateState(StateManager stateManager)
    {
        if (stateManager.animationPlayed.value)
        {
            if (stateManager.playerHp.value > 0 && stateManager.enemyHp.value > 0)
            {
                OnNextFightLoop();
            }
        }
        if (stateManager.playerHp.value <= 0 || stateManager.enemyHp.value <= 0)
        {
            stateManager.SwichState(stateManager.gameOverState);
        }

    }
}
