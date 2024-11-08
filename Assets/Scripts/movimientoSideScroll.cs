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

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("movX", movX);


        if (Input.GetButtonDown("Jump") && jumps > 0)
        {
            rbtopdown.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            jumps--;
        }
    }

    void FixedUpdate()
    {
        rbtopdown.velocity = new Vector2(movX* speed, rbtopdown.velocity.y);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo")) jumps = 2;
    }
   
}
