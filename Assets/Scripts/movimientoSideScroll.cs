using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoSideScroll : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jump;

    float movX;
    Rigidbody2D rbtopdown;
    Animator anim;
    int jumps = 2;

    // Start is called before the first frame update
    void Start()
    {
       rbtopdown = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
      
    }

    public void Move(float _movX)
    {
        rbtopdown.velocity = new Vector2(_movX* speed, rbtopdown.velocity.y);
        
    }
    
    public void Jump()
    {
        if (jumps > 0) 
        {
            rbtopdown.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            jumps--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo")) jumps = 2;
    }
}
