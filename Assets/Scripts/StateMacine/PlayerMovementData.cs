using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementData 
{
    private PlayerMovmentConfig config;

    public PlayerMovmentConfig Config => config;

    public PlayerMovementData(PlayerMovmentConfig playerMovmentConfig)
    {
        config = playerMovmentConfig;
    }

    // player
    public float _speed;
    public float _animationBlend;
    public float _targetRotation = 0.0f;
    public float _rotationVelocity;
    public float _verticalVelocity;
    public float _terminalVelocity = 53.0f;

    public bool IsMoving = true;
}
