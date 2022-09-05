using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEx : MonoBehaviour

{
    PlayerControl moveScript;

    static public float dashSpeed = 50;
    static public int countToDash = 0;
    static public float dashTime = 0.2f;
    private float DashTimer=2f;
    private bool DashCheck = false;
    
    void Start()
    {
        moveScript = GetComponent<PlayerControl>();
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !DashCheck)
        {
            if (countToDash < 2)
            {
                StartCoroutine(Dash());
                countToDash++;
            }
        }
        if (countToDash == 2)
        {
            DashCheck = true;
            DashTimeControl();
        }
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;

        while(Time.time < startTime + dashTime) 
        {
            moveScript.PlayerControler.Move(moveScript.moveDir * dashSpeed * Time.deltaTime);
            
            yield return  null;
        }
    }
    private void DashTimeControl()
    {
        if (DashCheck == true)
        {
            DashTimer -= Time.deltaTime;
        }

        if (DashTimer < 0)
        {
            DashCheck = false;
            DashTimer = 2f;
            countToDash = 0;
        }
    }
}
