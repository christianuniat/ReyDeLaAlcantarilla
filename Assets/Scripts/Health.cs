using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [NonSerialized] public int CurrentHealth;
    [SerializeField] int _maxhealth;
    [SerializeField] Slider slider;
    [SerializeField] float invinsebleTime;
    bool _invincible = false;
    private void Start()
    {
        CurrentHealth = _maxhealth;
        _invincible = false;
        if (slider != null) 
        {
            slider.maxValue = _maxhealth; 
            slider.value = _maxhealth;
        }
    }

    public void GotHit()
    {
        CurrentHealth--;
        slider.value = CurrentHealth;
        if (CurrentHealth <= 0) { Destroy(gameObject); }
        _invincible = true;
        StartCoroutine(Invincible());
    }

    IEnumerator Invincible()
    {
        GetComponent<SpriteRenderer>().color=new Color(1,1,1,.5f);
        Physics2D.IgnoreLayerCollision(6, 7,true);
        yield return new WaitForSeconds(invinsebleTime);
        GetComponent<SpriteRenderer>().color=new Color(1,1,1,1f);
        _invincible = false;
        Physics2D.IgnoreLayerCollision(6, 7,false);


    }
}
