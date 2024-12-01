using System;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    movimientoSideScroll movement;
    ataquesidescroller ataquesidescroller;

    float movX;
    bool facingRight=true;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<movimientoSideScroll>();
        ataquesidescroller = GetComponent<ataquesidescroller>();
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump")) movement.Jump();
        if (Input.GetButtonDown("Fire1")) ataquesidescroller.Ataca();

        if (movX > 0 && !facingRight) Flip();
        if (movX < 0 && facingRight) Flip();

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
}
