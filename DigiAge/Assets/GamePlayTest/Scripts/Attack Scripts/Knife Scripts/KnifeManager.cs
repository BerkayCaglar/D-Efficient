using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeManager : MonoBehaviour
{
    [SerializeField]private GameObject knife;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(Instantiate(knife, transform.localPosition + new Vector3(0f,1f,0f), transform.rotation),5);
        }
    }
}