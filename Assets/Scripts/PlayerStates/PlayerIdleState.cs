using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : State
{
    Player _parent;
    PlayerMovementState _movementState;
    Rigidbody2D _rb;

    public PlayerIdleState(Player player)
    {
        _parent = player;
        _movementState = new PlayerMovementState(_parent,this);
        _rb = _parent.GetComponent<Rigidbody2D>();
    }


    public override void Enter() 
    {
        _parent.animator.Play("Idle");
        _rb.velocity = new Vector2(_parent.movX * _parent.Speed * Time.deltaTime * 1000, _rb.velocity.y);
        return; 
    }
    public override void Exit() { return; }
    public override State FrameUpdate() 
    {
        if (_parent.movX != 0.0f) { return _movementState; }
        return null; 
    }
}
