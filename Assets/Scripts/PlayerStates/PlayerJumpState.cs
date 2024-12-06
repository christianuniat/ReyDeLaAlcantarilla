using UnityEngine;

public class PlayerJumpState : State
{
    Player _parent;
    State _idleState;
    Rigidbody2D _rb;
    float _jumpForce;

    public PlayerJumpState(Player player, State idleState)
    {
        _parent = player;
        _idleState = idleState;
        _rb = player.GetComponent<Rigidbody2D>();
        _jumpForce = Mathf.Sqrt(_parent.JumpHeight*(Physics2D.gravity.y*_rb.gravityScale)*-2)*_rb.mass;
    }

    public override void Enter()
    {
        _parent.animator.Play("Jump");
        _jumpForce = Mathf.Sqrt(_parent.JumpHeight * (Physics2D.gravity.y * _rb.gravityScale) * -2) * _rb.mass;
        Jump();
    }
    public override void Exit()
    {
        _rb.gravityScale = _parent.gravityScale;
    }
    public override State FrameUpdate()
    {
        if (_rb == null) { return null; }
        if (_parent.isOnFloor) { return _idleState; }
        if (Input.GetButtonDown("Jump")) { Jump(); }
        
        _rb.velocity = new Vector2(_parent.movX * _parent.Speed * Time.deltaTime * 500, _rb.velocity.y);
        _rb.gravityScale = _parent.gravityFall;
        if (_rb.velocity.y > 0) { _rb.gravityScale = _parent.gravityScale; }


        return null;
    }
    void Jump()
    {
        if (_parent.CurrentJumpCount > 0)
        {
            _rb.velocity.Set(_rb.velocity.x, 0.0f);
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _rb.gravityScale = _parent.gravityScale;

            _parent.CurrentJumpCount--;
        }
    }
}
