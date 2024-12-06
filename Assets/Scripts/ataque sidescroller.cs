using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataquesidescroller : MonoBehaviour
{
    [SerializeField] float lifeTime;
    [SerializeField] GameObject sword;
    


    public void Start()
    {
        sword.SetActive(false);
    }
    public void Ataca() 
    {
        sword.SetActive(true);
        StartCoroutine(AtaqueLife());
    }

    IEnumerator AtaqueLife()
    {
        yield return new WaitForSeconds(lifeTime);
        sword.SetActive(false);
    }
}
