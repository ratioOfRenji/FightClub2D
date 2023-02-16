using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    BaseState currentState;

    public WaitingState waitingState = new WaitingState();
    public PreparationState preparationState = new PreparationState();
    public FightState fightState = new FightState();
    public GameOverState gameOverState = new GameOverState();


    public IntVariable playersInRoom;
    public IntVariable timer;
    public IntVariable playerHp;
    public IntVariable enemyHp;
    public BoolVariable playersBool;
    public BoolVariable opponentsBool;
    public BoolVariable animationPlayed;

    


    void Start()
    {
        currentState = waitingState;
        currentState.EnterState(this);
    }


    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwichState(BaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
