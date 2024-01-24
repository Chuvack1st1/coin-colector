using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IdleState : State
{
    private Animator _animator;
    
    public IdleState(PlayerMovmentStateMachine playerMovmentStateMachine) : base(playerMovmentStateMachine)
    {
        _animator = playerMovmentStateMachine.Actor.GetComponentInChildren<Animator>();
    }
    public override void UpdateState()
    {
        base.UpdateState();
        _animator.SetBool("IsStay", true);
    }

    public override bool CanEnterInState()
    {
        return false;
    }
}
