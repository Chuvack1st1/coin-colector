using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    private GameObject _actor;
    private PlayerMovementData _movementData;

    private Animator _animator;
    private CharacterController _controller;
    private PlayerInputMovement _input;
    private GameObject _mainCamera;

    private float _animationBlend;

    private int _animIDSpeed;
    private int _animIDMotionSpeed;

    public WalkState(PlayerMovmentStateMachine playerMovmentStateMachine) : base(playerMovmentStateMachine)
    {
        _actor = playerMovmentStateMachine.Actor;
        _movementData = _actor.GetComponentInChildren<PlayerView>().PlayerModel.PlayerMovementData;

        if (_mainCamera == null)
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }

        _animator = _actor.GetComponentInChildren<Animator>();
        _animIDSpeed = Animator.StringToHash("Speed");
        _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");

        _controller = _actor.GetComponent<CharacterController>();

        _input = new();
        _input.InitWaklingInput();

        OnStateEnterEvent += _input.EnableInput;
        OnStateExiteEvent += _input.DisableInput;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Move();
    }

    private void Move()
    {
        float targetSpeed = _input.sprint ? _movementData.Config.SprintSpeed : _movementData.Config.MoveSpeed;

        if (_input.move == Vector2.zero) targetSpeed = 0.0f;

        float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;

        float speedOffset = 0.1f;
        float inputMagnitude = _input.analogMovement ? _input.move.magnitude : 1f;

        if (currentHorizontalSpeed < targetSpeed - speedOffset ||
            currentHorizontalSpeed > targetSpeed + speedOffset)
        {
            _movementData._speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude,
                Time.deltaTime * _movementData.Config.SpeedChangeRate);

            _movementData._speed = Mathf.Round(_movementData._speed * 1000f) / 1000f;
        }
        else
        {
            _movementData._speed = targetSpeed;
        }

        _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * _movementData.Config.SpeedChangeRate);
        if (_animationBlend < 0.01f) _animationBlend = 0f;

        Vector3 inputDirection = new Vector3(_input.move.x, 0.0f, _input.move.y).normalized;

        if (_input.move != Vector2.zero)
        {
            _movementData._targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg +
                              _mainCamera.transform.eulerAngles.y;
            float rotation = Mathf.SmoothDampAngle(_actor.transform.eulerAngles.y, _movementData._targetRotation, ref _movementData._rotationVelocity,
                _movementData.Config.RotationSmoothTime);

            _actor.transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        }


        Vector3 targetDirection = Quaternion.Euler(0.0f, _movementData._targetRotation, 0.0f) * Vector3.forward;

        _controller.Move(targetDirection.normalized * (_movementData._speed * Time.deltaTime));

        

        _animator.SetFloat(_animIDSpeed, _animationBlend);
        _animator.SetFloat(_animIDMotionSpeed, inputMagnitude);
    }

    public override bool CanEnterInState()
    {
        return true;
    }
}
