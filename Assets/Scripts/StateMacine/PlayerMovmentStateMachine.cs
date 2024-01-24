using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class PlayerMovmentStateMachine
{

    private List<State> _states = new();

    private State _startState = null;

    private State _currentState = null;

    private GameObject _actor;

    public GameObject Actor => _actor;

    public PlayerModel PlayerModel { get; private set; }

    public PlayerMovmentStateMachine(PlayerModel playerModel, GameObject actor)
    {
        _actor = actor;

        PlayerModel = playerModel;

        AddState(new IdleState(this));
        AddState(new WalkState(this));

        SetStartState(_states[0]);

        _states[0].AddTransition(_states[1]);
        _states[1].AddTransition(_states[0]);

        SetCurrentState(_startState);
    }

    public void OnUpdate()
    {
        _currentState.UpdateState();

        foreach (var state in _states)
        {
            var possibleTransition = state.TryFindPossibleTransition();
            if (possibleTransition != null)
            {
                if (possibleTransition.CurrentState == _currentState)
                {
                    SetCurrentState(possibleTransition.NextState);
                }
            }
        }
    }

    private void SetCurrentState(State state)
    {
        if (state == null)
        {
            Debug.LogWarning("You try set current state by non initial state");
            return;
        }

        if (_currentState != null)
        {
            DisableCurrentState();
        }

        _currentState = state;

        _currentState.OnStateEnterEvent.Invoke();
    }

    private void DisableCurrentState()
    {
        _currentState.OnStateExiteEvent.Invoke();
    }
    private void SetStartState(State state)
    {
        _startState = state;
    }
    public void AddState(State state)
    {
        _states.Add(state);
    }

    public void RemoveState(State state)
    {
        _states.Remove(state);
    }
}
