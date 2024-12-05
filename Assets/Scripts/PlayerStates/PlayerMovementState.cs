using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : State
{
    Player _parent;
    State _idleState;
    Rigidbody2D _rb;

    public PlayerMovementState(Player player,State idleState)
    {
        _parent = player;
        _idleState = idleState;
        _rb=_parent.GetComponent<Rigidbody2D>();
    }

    public override void Enter()
    {
        _parent.animator.Play("Walk");
        return;
    }
    public override void Exit() { return; }
    public override State FrameUpdate() 
    {
        if (_rb == null) { return null; }
        if (_parent.movX == 0.0f && _parent.isOnFloor) { return _idleState; }
        _rb.velocity= new Vector2(_parent.movX * _parent.Speed*Time.deltaTime*1000, _rb.velocity.y);
        return null;
    }

}
