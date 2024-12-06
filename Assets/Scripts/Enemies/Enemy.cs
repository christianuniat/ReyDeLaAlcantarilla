using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int Health;

    bool _invincible = false;
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

    IEnumerator Invincible() 
    {
        yield return new WaitForSeconds(1f);
        _invincible=false;
    }
}
