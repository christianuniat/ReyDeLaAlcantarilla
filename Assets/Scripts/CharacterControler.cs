using System;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    movimientoSideScroll movement;
    ataquesidescroller ataquesidescroller;
    Animator animator;
    bool isOnFloor=false;
    bool isOnWall=false;

    float movX;
    bool facingRight=true;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<movimientoSideScroll>();
        ataquesidescroller = GetComponent<ataquesidescroller>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        movX = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump")) movement.Jump();
        if (Input.GetButtonDown("Fire1")) ataquesidescroller.Ataca();

        if (movX > 0 && !facingRight) Flip();
        if (movX < 0 && facingRight) Flip();
        
        if (movX != 0) 
        {
            animator.Play("Walk");
            if (!isOnFloor) { animator.Play("Jump"); }
        }
        else animator.Play("Idle");



    }

    void Flip()
    {
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void FixedUpdate()
    {
        movement.Move(movX);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isOnFloor = (collision.gameObject.tag == "Suelo");
        isOnWall = (collision.gameObject.tag == "Wall");
    }
}
