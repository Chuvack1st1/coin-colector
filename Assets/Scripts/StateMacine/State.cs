using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    protected PlayerMovmentStateMachine _stateMachine;

    private List<Transition> _transitions = new List<Transition>();
    //protected bool _conditionToEnter;

    public Action OnStateEnterEvent;
    public Action OnStateExiteEvent;

    public State(PlayerMovmentStateMachine playerMovmentStateMachine)
    {
        _stateMachine = playerMovmentStateMachine;

        OnStateEnterEvent += OnEnter;
        OnStateExiteEvent += OnExite;
    }

    public virtual void UpdateState()
    {

    }
    public virtual bool CanEnterInState()
    {
        return false;
    }
    public Transition TryFindPossibleTransition()
    {
        foreach (var transition in _transitions)
        {
            if (transition.IsConditionMet())
            {
                return transition;
            }
        }
        return null;
    }

    public void AddTransition(State nextState)
    {
        if (nextState == null)
        {
            Debug.Log($"You try to add trantion to non existed State");
        }
        _transitions.Add(new Transition(this, nextState));
    }
    public void RemoveTransition(State nextState, Func<bool> condition)
    {
        var transitionToRemove = _transitions.Find(transition =>
            transition.CurrentState == this &&
            transition.NextState == nextState &&
            transition.Condition == condition);
        if (transitionToRemove == null)
        {
            Debug.Log($"Cant find the transition to Remove in {this}");
            return;
        }
        _transitions.Remove(transitionToRemove);
    }
    private void OnEnter()
    {
        Debug.Log("OnEnter" + this);
    }
    private void OnExite()
    {
        Debug.Log("OnExite" + this);
    }
}
