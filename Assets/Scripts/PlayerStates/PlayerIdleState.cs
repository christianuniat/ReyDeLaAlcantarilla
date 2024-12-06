using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : State
{
    Player _parent;
    PlayerMovementState _movementState;
    PlayerJumpState _jumpState;
    Rigidbody2D _rb;

    public PlayerIdleState(Player player)
    {
        _parent = player;
        _jumpState = new PlayerJumpState(_parent,this);
        _movementState = new PlayerMovementState(_parent,this,_jumpState);
        _rb = _parent.GetComponent<Rigidbody2D>();
    }


    public override void Enter() 
    {
        _rb.velocity = new Vector2(_parent.movX * _parent.Speed * Time.deltaTime * 1000, _rb.velocity.y);
        return; 
    }
    public override void Exit() { return; }
    public override State FrameUpdate()
    {
        if (_parent.movX != 0.0f) { return _movementState; }
        if(Input.GetButtonDown("Jump")&&_parent.isOnFloor) { return _jumpState; }
        _parent.animator.Play("Idle");

        return null; 
    }
}
