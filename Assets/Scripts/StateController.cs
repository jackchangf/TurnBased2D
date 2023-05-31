using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class StateController : MonoBehaviour
{
    public IState currentState;
    public Idle idleState = new Idle();
    public PlayerTurn playerTurn = new PlayerTurn();
    public EnemyTurn enemyTurn = new EnemyTurn();
    public bool battleOver;

    public delegate void EventDelegate();
    public event EventDelegate onStateChange; 

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate(this);
    }

    public void ChangeState(IState newState)
    {
        currentState?.OnExit(this);
        currentState = newState;
        currentState.OnEntry(this);
        onStateChange?.Invoke();
    }
}

public interface IState
{
    void OnEntry(StateController stateController);
    void OnUpdate(StateController stateController);
    void OnExit(StateController stateController);
}

public class Idle : IState
{
    public void OnEntry(StateController stateController)
    {
        Debug.Log("IDLE onentry");
    }

    public void OnUpdate(StateController stateController)
    {
        Debug.Log("IDLE onupdate");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateController.ChangeState(stateController.playerTurn);
        }
    }


    public void OnExit(StateController stateController)
    {
        Debug.Log("IDLE onexit");
    }

}

public class PlayerTurn : IState
{
    public void OnEntry(StateController stateController)
    {
        Debug.Log("PlayerTurn onentry");
    }

    public void OnUpdate(StateController stateController)
    {
        Debug.Log("PlayerTurn onupdate");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(stateController.battleOver) stateController.ChangeState(stateController.idleState);
            else stateController.ChangeState(stateController.enemyTurn);
        }

    }


    public void OnExit(StateController stateController)
    {
        Debug.Log("PlayerTurn onexit");
    }

}

public class EnemyTurn : IState
{
    public void OnEntry(StateController stateController)
    {
        Debug.Log("EnemyTurn onentry");
    }

    public void OnUpdate(StateController stateController)
    {
        Debug.Log("EnemyTurn onupdate");

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (stateController.battleOver) stateController.ChangeState(stateController.idleState);
            else stateController.ChangeState(stateController.playerTurn);
        }
    }


    public void OnExit(StateController stateController)
    {
        Debug.Log("EnemyTurn onexit");
    }

}
