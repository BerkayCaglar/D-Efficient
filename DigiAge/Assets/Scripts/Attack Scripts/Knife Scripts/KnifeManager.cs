using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeManager : MonoBehaviour
{
    [SerializeField]private GameObject knife;
    private int knifeCount = 3;
    private bool isCoolDown;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && knifeCount > 0)
        {
            Destroy(Instantiate(knife, transform.position + new Vector3(0f,0.8f,0f), transform.rotation),5);
            knifeCount--;
        }
        else if (knifeCount == 0 && !isCoolDown)
        {
            isCoolDown = true;
            StartCoroutine(KnifeCoolDown());
        }
    }

    private IEnumerator KnifeCoolDown()
    {
        yield return new WaitForSeconds(5);
        knifeCount = 3;
        isCoolDown = false;
    }
}