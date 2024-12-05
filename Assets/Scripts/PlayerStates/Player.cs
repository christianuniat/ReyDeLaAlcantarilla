using UnityEngine;

public class Player : MonoBehaviour
{


    public Animator animator;
    public bool isOnFloor = false;
    public bool isOnWall = false;
    public bool facingRight = true;
    public float movX;
    public float Speed;
    public float JumpForce;

    PlayerFiniteState stateMachine;
    State initialState;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        initialState = new PlayerIdleState(this);
        stateMachine = new PlayerFiniteState(this, initialState);
    }


    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxisRaw("Horizontal");
        if (movX > 0 && !facingRight) Flip();
        if (movX < 0 && facingRight) Flip();

        stateMachine.FrameUpdate();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isOnFloor = (collision.gameObject.tag == "Suelo");
        isOnWall = (collision.gameObject.tag == "Wall");
    }

    void Flip()
    {
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
