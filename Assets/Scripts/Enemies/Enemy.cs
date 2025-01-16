using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int Health;
    [SerializeField] float direccion=1f;
    
    movimientoSideScroll movement;
    
    bool isOnFloor = false;
    bool _invincible = false;

    void Start()
    {
        movement = GetComponent<movimientoSideScroll>();
        
    }

    public void GotHit() 
    {
        Debug.Log(Health);
        Debug.Log(_invincible);
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
        yield return new WaitForSeconds(.5f);
        _invincible=false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pared")) direccion = direccion * -1; 
    }
}
