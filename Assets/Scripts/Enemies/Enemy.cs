using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int Health;
    [SerializeField] float direccion=1f;
    [SerializeField] float invinsebleTime;

    movimientoSideScroll movement;
    
    bool _invincible = false;

    void Start()
    {
        movement = GetComponent<movimientoSideScroll>();
        
    }

    public void GotHit() 
    {
        if (_invincible) return;
        
        Health--;
        if (Health <= 0) { Destroy(gameObject); }
        _invincible=true;
        StartCoroutine(Invincible());

    }

    private void FixedUpdate()
    {
     
        movement.Move(direccion);
    }

    IEnumerator Invincible() 
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
        yield return new WaitForSeconds(invinsebleTime);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
        _invincible = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pared") || collision.gameObject.CompareTag("Suelo")) { direccion = direccion * -1; GetComponent<SpriteRenderer>().flipX = (direccion>0f); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pared") || collision.gameObject.CompareTag("Suelo")) { direccion = direccion * -1; GetComponent<SpriteRenderer>().flipX = (direccion > 0); }
    }
}
