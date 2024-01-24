using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class TestStateMachineClient : MonoBehaviour
{
    private PlayerMovmentStateMachine stateMachine = null;
    public void Init(PlayerModel playerModel)
    {
        stateMachine = new PlayerMovmentStateMachine(playerModel, gameObject);
    }

    private void Update()
    {
        stateMachine.OnUpdate();
    }
}
