using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public Button quit;
    // Start is called before the first frame update
    void Awake()
    {
        quit.onClick.AddListener(() => 
        {
            Debug.Log("Clicked");
            Application.Quit(); 
        }) ;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Time.timeScale = 1.0f;
            transform.gameObject.SetActive(false);
        }
    }
}
