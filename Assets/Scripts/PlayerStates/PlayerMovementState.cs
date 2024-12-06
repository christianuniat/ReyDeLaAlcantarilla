using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : State
{
    Player _parent;
    State _idleState;
    State _jumpState;
    Rigidbody2D _rb;

    public PlayerMovementState(Player player,State idleState,State jumpState)
    {
        _parent = player;
        _idleState = idleState;
        _jumpState = jumpState;
        _rb=_parent.GetComponent<Rigidbody2D>();
    }

    public override void Enter()
    {
        _parent.animator.Play("Walk");
        return;
    }
    public override State FrameUpdate() 
    {
        if (_rb == null) { return null; }
        if (_parent.movX == 0.0f && _parent.isOnFloor) { return _idleState; }
        if(Input.GetButtonDown("Jump")&&_parent.isOnFloor) { return _jumpState; }
        _rb.velocity= new Vector2(_parent.movX * _parent.Speed*Time.deltaTime*500, _rb.velocity.y);
        return null;
    }

}
