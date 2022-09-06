using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMekanik : MonoBehaviour
{

    public GameObject players;
    public float playerspeed;
    private float timer,timer2;
    private bool Qbasılı = true;
    private bool Qbırak = true;
          
      
    void Start()
    {
        Time.timeScale = 1f;
          
    }
  
     
    void Update()
    {
        Debug.Log(timer);
        Debug.Log(timer2);
        if (Input.GetKey(KeyCode.C))
        {
            loop();
              
        }
     
        loop2();
    }

    void loop()
    {
        timer =  timer + Time.deltaTime;
        if (timer<=2.5f)
        {
            timer =  timer + Time.deltaTime;
            Time.timeScale = 0.5f;
            playerspeed = (Time.timeScale * Time.timeScale)*(Time.timeScale*Time.timeScale);

        }
    }
    void loop2()
    {
        if (timer>2.5f) 
        {
            Time.timeScale = 1f;
            timer = timer + Time.deltaTime;
            
        }

        if (timer>=17.5)
        {
            timer = 0;
              
        }
    }
  
    
}