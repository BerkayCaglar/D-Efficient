using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private Animator playerAnimator;
    private GameObject Player;

    private void Awake()
    {
        Player = GameObject.Find("Player");
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            playerAnimator.SetBool("isRun",true);
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            playerAnimator.SetBool("isRun",false);
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerAnimator.SetBool("isAttack",true);
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            playerAnimator.SetBool("isAttack",false);
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerAnimator.SetBool("isCombo",true);
        }

        if (Input.GetKeyUp(KeyCode.E))
        { 
            playerAnimator.SetBool("isCombo",false);
        }
    }
}
