using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeRotationManager : MonoBehaviour
{
    private float axeRotateSpeed = 2000f,axeParentMovementSpeed = 10f;
    
    void Update()
    {
        // Axe'ı döndürüyoruz
        //transform.Rotate(Vector3.down * Time.deltaTime * axeRotateSpeed);
        
        // Axe'ı hareket ettiriyoruz.
        transform.parent.transform.Translate((Vector3.forward * Time.deltaTime *axeParentMovementSpeed));
    }
}
